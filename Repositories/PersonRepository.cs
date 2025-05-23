﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using aburbanoS5A.Models;
using SQLite;

namespace aburbanoS5A.Repositories
{
    public class PersonRepository
    {
        string dbPhat;
        private SQLiteConnection conn;

        public string statusMessage { get; set; }

        public PersonRepository(string path)
        {
            dbPhat = path;

        }
        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPhat);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Name = name };
                result = conn.Insert(person);
                statusMessage = string.Format("Dato ingresado");
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("ERROR" + ex);
            }
        }


        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("ERROR" + ex);
            }
            return new List<Persona>();
        }
        
    public void UpdatePerson(int id, string name)
        {
            int result = 0;
            try
            {
                Init();
                if (id <= 0 || string.IsNullOrEmpty(name))
                    throw new Exception("ID y nombre válidos son requeridos");

                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person is null)
                    throw new Exception("Persona no encontrada");

                person.Name = name;
                result = conn.Update(person);
                statusMessage = string.Format("Dato actualizado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR: " + ex.Message);
            }
        }

        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person is null)
                    throw new Exception("Persona no encontrada");

                result = conn.Delete(person);
                statusMessage = string.Format("Dato eliminado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR: " + ex.Message);
            }
        }
    }

}
