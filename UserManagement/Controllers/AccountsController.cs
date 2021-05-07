using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using UserManagement.Base;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Data;
using UserManagement.ViewModels;
using System.Text;
using System.Threading.Tasks;
using UserManagement.HashingPassword;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Accounts, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public AccountsController(AccountRepository accountRepository, MyContext myContext, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }
        
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            try
            {
                var checkId = registerVM.NIK;
                if(checkId != null)
                {
                    var newPerson = new Persons
                    {
                        NIK = registerVM.NIK,
                        FirstName = registerVM.FirstName,
                        LastName = registerVM.LastName,
                        Phone = registerVM.Phone,
                        BirthDate = registerVM.BirthDate,
                        Salary = registerVM.Salary,
                        Email = registerVM.Email
                    };
                    Persons user = null;
                    user = myContext.Persons.FirstOrDefault(u => u.Email == registerVM.Email);
                    if(user == null)
                    {
                        myContext.Persons.Add(newPerson);
                        myContext.SaveChanges();
                        var newAccount = new Accounts
                        {
                            NIK = newPerson.NIK,
                            Password = Hashing.HashPassword(registerVM.Password)
                        };
                        myContext.Accounts.Add(newAccount);
                        myContext.SaveChanges();
                        var newEducation = new Educations
                        {
                            Degree = registerVM.Degree,
                            GPA = registerVM.GPA,
                            University_Id = registerVM.University,
                        };
                        myContext.Educations.Add(newEducation);
                        myContext.SaveChanges();
                        var newProfiling = new Profilings
                        {
                            NIK = newAccount.NIK,
                            Education_Id = newEducation.Id
                        };
                        myContext.Profilings.Add(newProfiling);
                        myContext.SaveChanges();
                        var newRoleAccount = new RoleAccounts
                        {
                            AccountsNIK = newAccount.NIK,
                            RolesId = 2
                        };
                        myContext.RoleAccounts.Add(newRoleAccount);
                        myContext.SaveChanges();
                        return Ok(new {status = HttpStatusCode.Accepted, massage = "Register Succeed..." });
                    }
                    else
                    {
                        return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Email is already registered..." });
                    }
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : NIK column is null..." });
                }
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : There is something wrong with the column format input" });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Profile/{NIK}")]
        public ActionResult ViewData(string NIK)
        {
            //var cekPerson = myContext.Persons.Find(NIK);
            //var cekAccount = myContext.Accounts.Find(NIK);
            //var cekProfiling = myContext.Profilings.Find(NIK);
            //var cekEducation = myContext.Educations.Find(cekProfiling.Education_Id);
            //var cekUniversity = myContext.Universities.Find(cekEducation.University_Id);
            //RegisterVM registervm = new RegisterVM();
            //registervm.NIK = cekPerson.NIK;
            //registervm.FirstName = cekPerson.FirstName;
            //registervm.LastName = cekPerson.LastName;
            //registervm.Phone = cekPerson.Phone;
            //registervm.BirthDate = cekPerson.BirthDate;
            //registervm.Salary = cekPerson.Salary;
            //registervm.Email = cekPerson.Email;
            //registervm.Password = cekAccount.Password;
            //registervm.Degree = cekEducation.Degree;
            //registervm.GPA = cekEducation.GPA;
            //registervm.University = cekUniversity.Id;
            //return Ok(registervm);

            var data = from p in myContext.Persons
                       join a in myContext.Accounts on p.NIK equals a.NIK
                       join ar in myContext.RoleAccounts on a.NIK equals ar.AccountsNIK
                       join r in myContext.Roles on ar.RolesId equals r.Id
                       join pr in myContext.Profilings on a.NIK equals pr.NIK
                       join e in myContext.Educations on pr.Education_Id equals e.Id
                       where p.NIK == NIK
                       select new
                       {
                           NIK = p.NIK,
                           FirstName = p.FirstName,
                           LastName = p.LastName,
                           Role = r.Name,
                           Phone = p.Phone,
                           BirthDate = p.BirthDate,
                           Salary = p.Salary,
                           Email = p.Email,
                           Degree = e.Degree,
                           GPA = e.GPA,
                           University = e.University_Id
                       };
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("UserData")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> ViewDataAll()
        {
            var data = from p in myContext.Persons
                       join a in myContext.Accounts on p.NIK equals a.NIK
                       join ar in myContext.RoleAccounts on a.NIK equals ar.AccountsNIK
                       join r in myContext.Roles on ar.RolesId equals r.Id
                       join pr in myContext.Profilings on a.NIK equals pr.NIK
                       join e in myContext.Educations on pr.Education_Id equals e.Id
                       join u in myContext.Universities on e.University_Id equals u.Id
                       select new
                       {
                           NIK = p.NIK,
                           FirstName = p.FirstName,
                           LastName = p.LastName,
                           Role = r.Name,
                           Phone = p.Phone,
                           BirthDate = p.BirthDate,
                           Salary = p.Salary,
                           Email = p.Email,
                           Degree = e.Degree,
                           GPA = e.GPA,
                           University = u.Name
                       };
            
            return Ok(await data.ToListAsync());
        }

        [HttpPost("LogIn")]
        public ActionResult LogIn(LogInVM change)
        {
            //if(change.NIK != null)
            //{
            //    var cekPerson = myContext.Persons.Find(change.NIK);
            //    var cekAccount = myContext.Accounts.Find(change.NIK);
            //    var cekRoleAccount = myContext.RoleAccounts.Where(cr => cr.AccountsNIK == cekPerson.NIK).ToList();
            //    var role = myContext.Roles.Find(cekRoleAccount.RolesId);
            //    if (Hashing.ValidatePassword(change.Password, cekAccount.Password))
            //    {
            //        var data = from p in myContext.Persons
            //                   join a in myContext.Accounts on p.NIK equals a.NIK
            //                   join ar in myContext.RoleAccounts on a.NIK equals ar.AccountsNIK
            //                   join r in myContext.Roles on ar.RolesId equals r.Id
            //                   join pr in myContext.Profilings on a.NIK equals pr.NIK
            //                   join e in myContext.Educations on pr.Education_Id equals e.Id
            //                   join u in myContext.Universities on e.University_Id equals u.Id
            //                   where p.NIK == change.NIK
            //                   select new
            //                   {
            //                       NIK = p.NIK,
            //                       FirstName = p.FirstName,
            //                       LastName = p.LastName,
            //                       Role = r.Name,
            //                       Phone = p.Phone,
            //                       BirthDate = p.BirthDate,
            //                       Salary = p.Salary,
            //                       Email = p.Email,
            //                       Degree = e.Degree,
            //                       GPA = e.GPA,
            //                       University = u.Name
            //                   };

            //        var claims = new[] {
            //        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            //        new Claim(ClaimTypes.Role, role.Name),
            //        new Claim("NIK", cekPerson.NIK),
            //        new Claim("FirstName", cekPerson.FirstName),
            //        new Claim("LastName", cekPerson.LastName),
            //        new Claim("Role", role.Name),
            //        new Claim("Email", cekPerson.Email)
            //       };
            //foreach (RoleAccounts item in cekRoleAccount)
            //{
            //    new Claim(ClaimTypes.Role, myContext.Roles.Where(r => r.Id == item.RolesId).FirstOrDefault().Name);
            //}

            //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            //        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            //        string tokenFix = new JwtSecurityTokenHandler().WriteToken(token);

            //        return Ok((("Profile Data", data), ("Token Access", tokenFix), status: HttpStatusCode.Accepted, massage: "LogIn Succeed..."));
            //    }
            //    else
            //    {
            //        return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Wrong password or NIK.." });
            //    }
            //}
            if (change.Email != null)
            {
                var cekPerson = myContext.Persons.FirstOrDefault(cp => cp.Email == change.Email);
                //IEnumerable<Persons> persons = myContext.Persons.ToList();
                var cekAccount2 = myContext.Accounts.Find(cekPerson.NIK);
                var cekRoleAccount = myContext.RoleAccounts.Where(cr => cr.AccountsNIK == cekPerson.NIK).ToList();
                //var role = myContext.Roles.Find(cekRoleAccount.RolesId);
                if (Hashing.ValidatePassword(change.Password, cekAccount2.Password))
                {
                    var data = from p in myContext.Persons
                               join a in myContext.Accounts on p.NIK equals a.NIK
                               join ar in myContext.RoleAccounts on a.NIK equals ar.AccountsNIK
                               join r in myContext.Roles on ar.RolesId equals r.Id
                               join pr in myContext.Profilings on a.NIK equals pr.NIK
                               join e in myContext.Educations on pr.Education_Id equals e.Id
                               where p.NIK == cekPerson.NIK
                               select new
                               {
                                   NIK = p.NIK,
                                   FirstName = p.FirstName,
                                   LastName = p.LastName,
                                   Role = r.Name,
                                   Phone = p.Phone,
                                   BirthDate = p.BirthDate,
                                   Salary = p.Salary,
                                   Email = p.Email,
                                   Degree = e.Degree,
                                   GPA = e.GPA,
                                   University = e.University_Id
                               };
                    var claims = new List<Claim> 
                    {
                    //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("NIK", cekPerson.NIK),
                    new Claim("FirstName", cekPerson.FirstName),
                    new Claim("LastName", cekPerson.LastName),
                    new Claim("Email", cekPerson.Email)
                   };
                    foreach (RoleAccounts item in cekRoleAccount)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, myContext.Roles.Where(r => r.Id == item.RolesId).FirstOrDefault().Name));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    string tokenFix = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok((("Profile Data", data), ("Token Access", tokenFix), status: HttpStatusCode.Accepted, massage: "LogIn Succeed..."));
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Wrong password or Email.." });
                }
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : No NIK or Email input..." });
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM change)
        {
            if (change.NIK != null)
            {
                var cekAccount = myContext.Accounts.Find(change.NIK);
                if (Hashing.ValidatePassword(change.Password, cekAccount.Password))
                {

                    cekAccount.Password = Hashing.HashPassword(change.NewPassword);
                    myContext.Entry(cekAccount).State = EntityState.Modified;
                    myContext.SaveChanges();
                    return Ok("Password changed successfully...");
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Wrong old password or NIK.." });
                }
            }
            else if (change.Email != null)
            {
                string nik = null;
                IEnumerable<Persons> persons = myContext.Persons.ToList();
                foreach (Persons p in persons)
                {
                    if (p.Email == change.Email)
                    {
                        nik = p.NIK;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                var cekAccount2 = myContext.Accounts.Find(nik);
                if (Hashing.ValidatePassword(change.Password, cekAccount2.Password))
                {
                    cekAccount2.Password = Hashing.HashPassword(change.NewPassword);
                    myContext.Entry(cekAccount2).State = EntityState.Modified;
                    myContext.SaveChanges();
                    return Ok("Password changed successfully...");
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Wrong old password or Email.." });
                }
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "No NIK or Email input..." });
            }
        }

        [HttpPost("ForgotPassword")]
        public ActionResult SendMail(ChangePasswordVM change)
        {
            if (change.Email != null)
            {
                string nik = null;
                IEnumerable<Persons> persons = myContext.Persons.ToList();
                foreach (Persons p in persons)
                {
                    if (p.Email == change.Email)
                    {
                        nik = p.NIK;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (nik != null)
                {
                    var cekPerson = myContext.Persons.Find(nik); 
                    var cekAccount2 = myContext.Accounts.Find(nik);
                    string password = RandomString();
                    cekAccount2.Password = Hashing.HashPassword(password);
                    myContext.Entry(cekAccount2).State = EntityState.Modified;
                    myContext.SaveChanges();

                    DateTime d = DateTime.Now;
                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress("developit9@gmail.com");
                    mm.To.Add(new MailAddress(change.Email));
                    mm.Subject = $"[RESET PASSWORD REQUEST] {d.ToString("dd-MM-yyyy")}";
                    mm.Body = $"Hello {cekPerson.FirstName} {cekPerson.LastName}.\nYour new password is {password}\nHave a nice day...";
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("developit9@gmail.com", "Sembilan!@9");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mm);
                    return Ok("Email sent...");
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : Email is not registered..." });
                }
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.Forbidden, message = "Error : No Email input..." });
            }
        }

        public string RandomString()
        {
            int length = 7;
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
