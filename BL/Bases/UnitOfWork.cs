using BL.Interfaces;
using BL.Repostories;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private JrTaskDbContext EC_DbContext { get; set; }
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UnitOfWork(JrTaskDbContext EC_DbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.EC_DbContext = EC_DbContext;
        }
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }
        public void Dispose()
        {
            EC_DbContext.Dispose();
        }


        public AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext, _userManager, _roleManager);
                return account;
            }
        }


    }
}
