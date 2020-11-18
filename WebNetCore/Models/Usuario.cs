using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore.Models
{
    class Usuario
    {
        
        private String nombre;
        private String password;
        private Boolean pay;
        public Usuario(String nom, String pass,Boolean pay)
        {
            this.nombre = nom;
            this.password = pass;
            this.pay = pay;
        }
        public Usuario(String nom, String pass)
        {
            this.nombre = nom;
            this.password = pass;
            this.pay = false;
        }
        public String getNombre()
        {
            return this.nombre;
        }
        public String getPassword()
        {
            return this.password;
        }
        public Boolean getPay() {
            return this.pay;
        }
        public void setPassword(String pass) {
            this.password = pass;
        }

      

    }
}
