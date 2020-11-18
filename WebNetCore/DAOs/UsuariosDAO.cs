using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using WebNetCore.Models;

namespace WebNetCore.DAOs
{
    class UsuariosDAO
    {
        private static UsuariosDAO instancia;
        private DBConnection DB;
        private UsuariosDAO()
        {
            this.DB = DBConnection.getInstance();
        }

        // para poder usar unicamente 1 objeto;
        public static UsuariosDAO getInstancia()
        {
            if (instancia == null)
            {
                instancia = new UsuariosDAO();
            }
            return instancia;
        }

       

        // finders
        public Boolean checkUsuario(String nom, String pass)
        {
            var flag = false;
            var usuario = this.cargarUsuario(nom);
            if (usuario != null)
            {
             if (usuario.getNombre() == nom && usuario.getPassword() == pass) {
                flag = true;
                }
            }
            return flag;

        }
        public Boolean findUsuario(String nom) {
            var flag = false;
            var usuario = this.cargarUsuario(nom);

            if (usuario != null) { flag = true;  }

            return flag;
        }

        //Create
        public Boolean create(String user, String pass) {
            var flag = false;
            var QB = DB.getQueryBuilder();
            QB.setQuery("INSERT INTO usuario (`name`,`password`) VALUES (@user,@pass);");
            QB.addParam("@user", user);
            QB.addParam("@pass", pass);
            DB.abm(QB);

            if (this.findUsuario(user))
            {
                flag = true;
            }
            return flag;
        }


       //Read
        private Usuario cargarUsuario(String user)
        {
            var QB = DB.getQueryBuilder();
            QB.setQuery("SELECT name,password,pay FROM usuario WHERE name=@user");
            QB.addParam("@user", user);
            IDataReader reader = DB.select(QB);
            Usuario usuario = null;
            while (reader.Read())
            {
             
                usuario = new Usuario(reader.GetString(0), reader.GetString(1),reader.GetBoolean(2));

            }
            reader.Close();

            return usuario;
        }
        public Boolean checkPay(String user) {
            var usuario = cargarUsuario(user);
            return usuario.getPay();
        }

        //Update
        public Boolean cambiaPass(String user, String newpass) {
            var flag = false;
            var usuario= this.cargarUsuario(user);
            if (usuario != null) { 
                var QB = DB.getQueryBuilder();
                QB.setQuery("UPDATE usuario SET password=@pass WHERE name=@user");
                QB.addParam("@pass", newpass);
                QB.addParam("@user", user);
                DB.abm(QB);
                flag = true;
            }
            return flag;
        }
        //Delete
        public Boolean deleteUsuario(String user)
        {
            var flag = false;
            var usuario = this.cargarUsuario(user);
            if (usuario != null) {
                var QB = DB.getQueryBuilder();
                QB.setQuery("DELETE FROM usuario WHERE name=@user;");
                QB.addParam("@user", user);
                DB.abm(QB);
                flag = true;
            }
            return flag;
        }

    }
}

