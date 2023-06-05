using System;
using System.Collections.Generic;
using System.Text;

namespace _5T23_EssalhiAdam_CarrePolybe
{
    public struct MethodeTraitementMat
    {
        /**
        * Cryptage : crée une matrice de chiffrement pour une phrase donnée
        * IN phrase : phrase à crypter
        * IN matricesDeBase : matrice de base utilisée pour le cryptage
        * OUT chiffre : tableau de chiffres résultant du cryptage
        * HYPO : phrase et matricesDeBase sont non vides
                 phrase > 0
        */
        public void Cryptage(string phrase, out string[,] chiffre, string[,] matricesDeBase)
        {
            chiffre = new string[phrase.Length, 2];
            for (int a = 0; a < phrase.Length; a++)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int y = 1; y < 6; y++)
                    {
                        if (phrase[a].ToString() == "J" && matricesDeBase[i, y] == "I")
                        {
                            chiffre[a, 0] = matricesDeBase[0, i];
                            chiffre[a, 1] = matricesDeBase[y, 0];
                        }
                        else if (phrase[a].ToString() == matricesDeBase[i, y])
                        {
                            chiffre[a, 0] = matricesDeBase[0, i];
                            chiffre[a, 1] = matricesDeBase[y, 0];
                        }
                    }
                }
            }
        }
        /**
        * DeCryptage : déchiffre une matrice de chiffrement pour obtenir la phrase qui correspond
        * IN phrase :  phrase à décrypter
        * IN matricesDeBase : matrice de base utiliisée pour le décryptage
        * IN chiffre :  tableau contenant les chiffres à décrypter
        * OUT codeDechiffrer : phrase déchiffrée résultante
        * HYPO : matricesDeBase et chiffre sont non vides
                 chiffres > 0
        */
        public void DeCryptage(string phrase, out string codeDechiffrer, string[,] matricesDeBase, string[,] chiffre)
        {
            codeDechiffrer = "";
            for (int a = 0; a < chiffre.GetLength(0); a++)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int y = 1; y < 6; y++)
                    {

                        if (chiffre[a, 0] == matricesDeBase[0, i] && chiffre[a, 1] == matricesDeBase[y, 0])
                        {
                            codeDechiffrer += matricesDeBase[i, y];

                        }
                    }
                }
            }
        }
        /**
        * RetireEspaces : crée une chaine de caractères sans espace
        * IN chaine : chaine de caractères dans laquelle on retire les espaces
        * OUT copie conforme de la chaine de départ sans les espaces
        * HYPO : chaine non vide
        */
        public string RetireEspaces(string chaine)
        {
            string newChaine = "";
            string carExt;
            int lg = chaine.Length;
            for (int i = 0; i < lg; i++)
            {
                carExt = chaine.Substring(i, 1);
                if (carExt != " ")
                {
                    newChaine += carExt;
                }
            }
            return newChaine;
        }
        /**
        * CreationMatrice : crée une matrice de base à partir d'un code donné
        * IN code : code (ou mot clé) utilisé pour remplir la matrice de base
        * OUT matricesDeBase : matrice de base résultante (avec le code donné)
        * HYPO : code est non vide
                 code <= 25
        */
        public void CreationMatrice(string code, out string[,] matricesDeBase)
        {
            int ligne = 1;
            int colonne = 1;

            string[] alphabet = new string[25] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", };
            matricesDeBase = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                matricesDeBase[0, i] = i.ToString();
            }
            for (int i = 0; i < 6; i++)
            {
                matricesDeBase[i, 0] = i.ToString();
            }

            for (int codeInt = 0; codeInt < code.Length; codeInt++)
            {

                for (int alphabetInt = 0; alphabetInt < 25; alphabetInt++)
                {
                    if (code[codeInt].ToString() == alphabet[alphabetInt])
                    {

                        matricesDeBase[ligne, colonne] = alphabet[alphabetInt].ToString();
                        alphabet[alphabetInt] = " ";
                        if (codeInt != code.Length)
                        {
                            colonne++;
                        }

                        if (colonne == 6 && codeInt != code.Length)
                        {
                            ligne++;
                            colonne = 1;
                        }

                    }
                }

            }
            for (int li = ligne; li < 6; li++)
            {
                for (int co = colonne; co < 6; co++)
                {
                    for (int alphabetInt = 0; alphabetInt < 25; alphabetInt++)
                    {

                        if (alphabet[alphabetInt].ToString() != " ")
                        {
                            matricesDeBase[li, co] = alphabet[alphabetInt].ToString();
                            alphabet[alphabetInt] = " ";
                            alphabetInt = 25;
                            if (co == 5)
                            {
                                colonne = 1;
                            }


                        }
                    }
                }
            }
            for (int i = 0; i < matricesDeBase.GetLength(0); i++)
            {
                for (int y = 0; y < matricesDeBase.GetLength(1); y++)
                {
                    Console.Write(matricesDeBase[i, y] + "|");
                }
                Console.WriteLine(" ");
            }

        }

        /// <summary>
        /// Savoir si l’entrée de l’utilisateur est bonne.
        /// </summary>
        /// <param name="entree">Entrée de l’utilisateur</param>
        /// <returns>Si l’entrée est bonne ou non</returns>
        public bool EntreeEstBonne(string entree)
        {
            for (int i = 0; i <= entree.Length - 1; i++) // i = Variable qui s’incrémente dans une boucle for (place dans le string)
            {
                int ic = entree[i]; // Valeur du caractère à la place "i" dans le string
                if (!(ic >= 65 && ic <= 90) && !(ic >= 97 && ic <= 122) && ic != 32) return false;
            }
            return true;
        }

        /// <summary>
        /// vérification et empêche l'utilisateur d'entrer une valeur string.
        /// </summary>
        /// <param name="question">demande à adresser à l'utilisateur</param>
        /// <param name="n">nombre entier récupéré</param>
        public void LireReel(out double n)
        {
            string nUser;

            nUser = Console.ReadLine();
            nUser = RetireEspaces(nUser);
            while (!double.TryParse(nUser, out n))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Attention ! vous devez entrer un nombre réel !");
                Console.ResetColor();
                nUser = Console.ReadLine();
                nUser = RetireEspaces(nUser);
            }
        }

    }
}