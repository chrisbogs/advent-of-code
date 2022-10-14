namespace AdventOfCodeShared.Models
{
    public class PasswordWithRule
    {
        public char Character { get; set; }
        public int First { get; set; }
        public int Second { get; set; }
        public string Password { get; set; } = "";
        public PasswordWithRule(char character, int minCount, int maxCount, string password)
        {
            this.Character = character;
            this.First = minCount;
            this.Second = maxCount;
            this.Password = password;
        }

        public bool IsValidv1()
        {
            var charCount = 0;
            foreach (var c in this.Password)
            {
                if (c.Equals(Character))
                {
                    charCount++;
                }
            }
            return First <= charCount && charCount <= Second;
        }
        // Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter. Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
        // Given the same example list from above:
        // 1-3 a: abcde is valid: position 1 contains a and position 3 does not.
        // 1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
        // 2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
        // How many passwords are valid according to the new interpretation of the policies?
        public bool IsValidv2()
        {
            var firstIndex = First - 1;
            var secondIndex = Second - 1;
            return Password.Length >= Second && Password[firstIndex] == Character && Password[secondIndex] != Character
            || Password[firstIndex] != Character && Password[secondIndex] == Character;
        }
    }
}
