using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucPass.Constants
{
    public class FileConstants
    {
        public const String GENERAL_FOLDER = @"C:\ProgramData\NucPass\";
        public const string DATABASE_FILE_NAME = "database";
        public const string DATABASE_FILE_EXTENSION = ".db3";
        public const string DATABASE_FILE = DATABASE_FILE_NAME + DATABASE_FILE_EXTENSION;
        public const string DATABASE_FILE_COMBINED = GENERAL_FOLDER + DATABASE_FILE;
        public const string DATABASE_FILE_ENCRYPTED = GENERAL_FOLDER + DATABASE_FILE_NAME + ".dbcrypt";
    }
}
