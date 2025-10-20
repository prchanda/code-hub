public class Solution {
    public int Compress(char[] chars) {
        int write = 0;   // index to write compressed chars
        int count = 1;   // count of current group

        for (int read = 0; read < chars.Length; read++) {
            // If next char is different OR we reached end
            if (read == chars.Length - 1 || chars[read] != chars[read + 1]) {
                // Write the current char
                chars[write++] = chars[read];

                // Write the count if > 1
                if (count > 1) {
                    foreach (char c in count.ToString()) {
                        chars[write++] = c;
                    }
                }

                count = 1; // reset for next group
            } else {
                count++;
            }
        }

        return write; // length of compressed string
    }
}
