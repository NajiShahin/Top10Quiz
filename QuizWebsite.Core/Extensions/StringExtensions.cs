using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsSimilar(this string userAnswer, string answer) //userAnswer is what user answered, answer is the real answer
        {
            answer = answer.ToUpper().Replace("THE ", "").Replace("OF ", "")
                .Replace("AND ", "").Replace(".", "").Replace("-", "")
                .Replace("!", "");
            answer = answer.Replace(" THE", "").Replace(" OF", "")
                .Replace(" AND", "").Replace(" ", "");
            userAnswer = userAnswer.ToUpper().Replace("THE ", "").Replace("OF ", "")
                .Replace("AND ", "").Replace(".", "").Replace("-", "")
                .Replace("!", "");
            userAnswer = userAnswer.Replace(" THE", "").Replace(" OF", "")
                .Replace(" AND", "").Replace(" ", "");
            if (answer == userAnswer)
                return true;

            if (answer.Length == userAnswer.Length && answer.Length >= 5)
            {
                int count = 0;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] != userAnswer[i])
                        count++;
                }
                if (count <= 1)
                    return true;
                return false;
            }
            if (answer.Length == userAnswer.Length - 1 && answer.Length >= 5)
            {
                int count = 0;
                for (int i = 0; i < userAnswer.Length + 1; i++)
                {
                    if (answer.Length != i)
                    {
                        if (answer[i] != userAnswer[i] && count == 0)
                        {
                            userAnswer = userAnswer.Remove(i, 1);
                            count++;
                            if (answer == userAnswer)
                                return true;
                        }
                    }
                    else
                    {
                        userAnswer = userAnswer.Remove(userAnswer.Length - 1, 1);
                        if (answer == userAnswer)
                            return true;
                    }
                }
                if (answer == userAnswer)
                    return true;
                return false;
            }
            if (answer.Length == userAnswer.Length + 1 && answer.Length >= 5)
            {
                int count = 0;
                for (int i = 0; i < userAnswer.Length; i++)
                {
                    if (userAnswer.Length != i)
                    {
                        if (answer[i] != userAnswer[i])
                        {
                            if (count == 0)
                                count++;

                            if (answer[i + 1] != userAnswer[i])
                            {
                                count++;
                            }
                        }
                    }
                }
                if (count <= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
