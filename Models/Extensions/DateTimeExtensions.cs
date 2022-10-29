namespace SocialMedia.Models;

public static class DateTimeExtensions {
    public static string TimeElapsed(this DateTime value) {
        TimeSpan totalTime = DateTime.Now - value;

        String elapsedTime = "a moment ago";

        if(totalTime.TotalDays >= 365) elapsedTime = $"{(int) totalTime.TotalDays / 365} y";
        else if(totalTime.TotalDays >= 30) elapsedTime = $"{(int) totalTime.TotalDays / 30} m";
        else if(totalTime.TotalDays >= 1) elapsedTime = $"{(int) totalTime.TotalDays} d";
        else if(totalTime.TotalMinutes >= 60) elapsedTime = $"{(int) totalTime.TotalMinutes / 60} h";
        else if(totalTime.TotalMinutes >= 1) elapsedTime = $"{(int) totalTime.Minutes} min";
        
        return elapsedTime;
    }
} 