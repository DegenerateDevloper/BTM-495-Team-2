using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.IO;
using System.Reflection;
using System;


public abstract class User
{
	// abstract class = modifier that indicates missing component or incomplete implementation, cannot be instantiated
    public int user_ID { get; set; }
    public string user_fname { get; set; }
    public string user_lname { get; set; }
    public string user_phone { get; set; }


    /**
     * Verify if the Id of the user is existant pr not
     */
    public bool verifyId(string path, string un, string id) 
    {
        if (pw != "" && id != "")
        {
            StreamReader existingUsers = new StreamReader(path);
            var counter = 0;
            string line;
            while ((line = existingUsers.ReadLine()) != null)
            {
                string[] existingUser = line.Split(new string[] { ": " }, StringSplitOptions.None);
                if (existingUser[0].Equals(un) && existingUser[1].Equals(id))
                {
                    counter = 2;
                    break;
                }
                else if (existingUser[0].Equals(un))
                {
                    counter++;
                    break;
                }
            }
            existingUsers.Close();

            if (counter == 2)
            {
                //id is approved
                return true;
            }
            else if (counter == 1)
            {
                //username is correct, but the id isn't
                return false;
            }
            else
            {
                //username and/or id doesn't exist in the system
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /**
     * Validate if username and the password or valid or not.
     * If password is valid, now we need to check if username and password exists or not before creating
     * Needs to work with some kind of a data store (DB) in general for purpose security.
     */
    public bool verifyPassword(string path, string email, string pw) 
    {
        if (pw != "" && un != "")
        {
            var hashedpw = Hash_SHA1(pw);
            StreamReader existingUsers = new StreamReader(path);
            var counter = 0;
            string line;
            while ((line = existingUsers.ReadLine()) != null)
            {
                string[] existingUser = line.Split(new string[] { ": " }, StringSplitOptions.None);
                if (existingUser[0].Equals(un) && existingUser[1].Equals(hashedpw))
                {
                    counter = 2;
                    break;
                }
                else if (existingUser[0].Equals(un))
                {
                    counter++;
                    break;
                }
            }
            existingUsers.Close();

            if (counter == 2)
            {
                //Password is approved
                return true;
            }
            else if (counter == 1)
            {
                //username is correct, but the password isn't
                return false;
            }
            else
            {
                //username and/or password doesn't exist in the system
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /**
     * Used to hash and dehash passwords, a security measure to not leak such private info easily.
     */
    public static string Hash_SHA1(string input)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }

}