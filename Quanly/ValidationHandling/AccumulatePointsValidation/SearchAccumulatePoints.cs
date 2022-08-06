namespace Quanly.ValidationHandling.AccumulatePointsValidation
{
    public class SearchAccumulatePoints
    {
        public string ValidateSearchAccumulatePoint(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return "Please enter the keyword to search";
            if (keyword.Count() > 50)
                return "The keyword is out of range";
            
            return "ok";
        }
    }
}
