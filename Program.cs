internal class Program
{
    private static void Main(string[] args)
    {
        string plaintext = "The quick brown fox jumps over 13 lazy dogs";
        string key = "cryptii";

        string encrypted = VigenereEncrypt(plaintext, key);
        Console.WriteLine($"Plaintext: {plaintext}");
        Console.WriteLine($"Key: {key}");
        Console.WriteLine($"Encrypted text: {encrypted}");

        string decrypted = VigenereDecrypt(encrypted, key);
        Console.WriteLine($"Decoded text: {decrypted}");
    }

    private static string VigenereEncrypt(string plaintext, string key)
    {
        return VigenereCipher(plaintext, key, encrypt: true);
    }

    private static string VigenereDecrypt(string ciphertext, string key)
    {
        return VigenereCipher(ciphertext, key, encrypt: false);
    }

    private static string VigenereCipher(string text, string key, bool encrypt)
    {
        string result = "";
        int keyIndex = 0;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                int shift = char.ToUpper(key[keyIndex % key.Length]) - 'A';
                int charCode = char.ToUpper(c) - 'A';

                if (!encrypt)
                    shift = -shift;

                int newCharCode = (charCode + shift) % 26;
                if (newCharCode < 0)
                    newCharCode += 26;

                result += (char)('A' + newCharCode);
                keyIndex++;
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
}