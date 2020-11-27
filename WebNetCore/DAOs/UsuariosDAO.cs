using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
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
        
        public Boolean validarKey(String key,String name) { 
        var QB = DB.getQueryBuilder();
            QB.setQuery("SELECT * FROM llaves WHERE id=@key");
            QB.addParam("@key", key);
            IDataReader reader = DB.select(QB);
            var validado = false;
            while (reader.Read())
            {
                if (!reader.GetBoolean(1))
                {
                    var QB2 = DB.getQueryBuilder();
                    QB2.setQuery("UPDATE llaves SET used=1 WHERE id=@key");
                    QB2.addParam("@key", key);
                    DB.abm(QB2);

                    var QB3 = DB.getQueryBuilder();
                    QB3.setQuery("UPDATE usuario SET pay=1 WHERE name=@name");
                    QB3.addParam("@name", name);
                    DB.abm(QB3);

                    validado = true;
                    
                }
                

            }
            reader.Close();
            return validado;
        }
        public Boolean checkPay(String user) {
            var usuario = cargarUsuario(user);
            if (usuario != null)
            {
                return usuario.getPay();
            }
            return false;
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

