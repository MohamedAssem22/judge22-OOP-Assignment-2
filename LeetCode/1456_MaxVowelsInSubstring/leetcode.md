
## Submission Details

### Problem: Maximum Number of Vowels in a Substring of Given Length
- **Submission Link:** [View Submission on LeetCode](https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/submissions/2166410133/)
- **Difficulty:** Medium
- **Topic:** Sliding Window, String

#### Brief Description / Solution Approach:
This problem requires finding the maximum number of vowels in any substring of a given length `k` within a string `s`. 
The optimal approach uses the **Sliding Window** technique:
1. Count the number of vowels in the first window of size `k`.
2. Slide the window one character to the right at a time: add the incoming character (if it's a vowel) and remove the outgoing character (if it was a vowel).
3. Keep track of the maximum vowel count encountered during the process.