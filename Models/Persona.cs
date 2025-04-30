﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace aburbanoS5A.Models
{
    public class Persona
    {

        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [MaxLength(25)]  public string Name {  get; set; }
    }
}
