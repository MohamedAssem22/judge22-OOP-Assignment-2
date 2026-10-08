class Solution
{
    bool IsVowel(char c)
    {
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }
    public int MaxVowels(string s, int k)
    {
        int ans = 0, l = 0, r = 0, cntt = 0;
        for (int i = 0; i < k; i++) cntt += (IsVowel(s[i]) == true ? 1 : 0);
        l = 0; r = k - 1;
        while (r < s.Length)
        {
            ans = Math.Max(cntt, ans);
            cntt -= (IsVowel(s[l]) == true ? 1 : 0);
            l++;
            r++;
            if (r < s.Length)
                cntt += (IsVowel(s[r]) == true ? 1 : 0);
        }
        return ans;
    }
};