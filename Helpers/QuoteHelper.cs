namespace SimoshStore;

public class QuoteHelper
{
    public static string GenerateQuote()
    {
        string[] quotes = new string[]
        {
            "Success is not final, failure is not fatal: It is the courage to continue that counts.",
            "The only way to do great work is to love what you do.",
            "In the end, we will remember not the words of our enemies, but the silence of our friends.",
            "It is never too late to be what you might have been.",
            "The only limit to our realization of tomorrow is our doubts of today.",
            "The best way to predict your future is to create it.",
            "Do not go where the path may lead, go instead where there is no path and leave a trail.",
            "Believe you can and you're halfway there.",
            "You must be the change you wish to see in the world.",
            "It does not matter how slowly you go as long as you do not stop.",
            "The only impossible journey is the one you never begin.",
            "Don't watch the clock; do what it does. Keep going.",
            "What lies behind us and what lies before us are tiny matters compared to what lies within us.",
            "Our lives begin to end the day we become silent about things that matter.",
            "I have not failed. I've just found 10,000 ways that won't work.",
            "You miss 100% of the shots you don't take.",
            "The purpose of life is not to be happy. It is to be useful, to be honorable, to be compassionate, to have it make some difference that you have lived and lived well.",
            "The future belongs to those who believe in the beauty of their dreams.",
            "Success usually comes to those who are too busy to be looking for it.",
            "Hardships often prepare ordinary people for an extraordinary destiny."
        };
        Random rnd = new Random();
        int index = rnd.Next(quotes.Length);
        return quotes[index];
    }
}
