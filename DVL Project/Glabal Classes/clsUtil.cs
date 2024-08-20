using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DVL_Project.Glabal_Classes
{
    public class clsUtil
    {
        public static string Key
        {
            get
            {
                return "0123456789012345";
            }
        }

        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"G:\DVLD Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static bool SaveLoginRegister(string Username, string Password)
        {
            bool IsFound = false;

            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
                {
                    try
                    {
                        using (RegistryKey SubKey = baseKey.OpenSubKey(@"SOFTWARE", true))
                        {
                            try
                            {
                                using (RegistryKey SubKey2 = SubKey.CreateSubKey("DVLD", true))
                                {
                                    if (SubKey2 != null)
                                    {
                                        SubKey2.SetValue("Username", Username); // (valueName, valueData).
                                        SubKey2.SetValue("Password", Encrypt(Password)); // (valueName, valueData).

                                        IsFound = true;
                                    }
                                    // else the folder 'DVLD' is already exist in 'SOFTWARE'.
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show($"Error in SubKey2 : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error in SubKey : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

                if (IsFound)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Base Key : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // if 'IsFound'= false, means the folder 'DVLD' is Exist.
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            try
            {
                Registry.SetValue(Path, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(Path, "Password", Password, RegistryValueKind.String);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error for Set Values : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// this Method for load Login Registry.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns> this return 'boolean data type' if true it will fill info in text box </returns>
        public static bool LoadLoginInfo(ref TextBox Username, ref TextBox Password)
        {
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            string password = "";
            string username = "";

            try
            {
                username = Registry.GetValue(Path, "Username", null) as string;
                password = Decrypt(Registry.GetValue(Path, "Password", null).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error for Set Values : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (username == "" || password == "")
                return false;

            // write information in Text boxes and change fore color from 'gray' to 'black'.
            Username.ForeColor = Color.Black;
            Username.Text = username;

            Password.ForeColor = Color.Black;
            Password.Text = password;
            Password.UseSystemPasswordChar = true;

            return true;
        }

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }

    }
}
