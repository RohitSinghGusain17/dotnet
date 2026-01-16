using System.Collections;

public class MeditationCenter
{
    public int MemberId{get; set;}
    public int Age{get; set;}
    public double Weight{get; set;}
    public double Height{get; set;}
    public string? Goal{get; set;}   
    public double BMI{get; set;}

    public static ArrayList memberList = new ArrayList();

    public void AddYogaMember(int memberid, int age, double weight, double height, string goal)
    {
        memberList.Add(new MeditationCenter{MemberId=memberid, Age= age, Weight=weight, Height=height, Goal=goal});
    }

    public double CalculateBMI(int memberid)
    {
        foreach(MeditationCenter i in memberList)
        {
            if (i.MemberId == memberid)
            {
                i.BMI=i.Weight/(i.Height*i.Height);
                return Math.Round(i.BMI,2);
            }
        }
        return 0;
    }

    public int CalculateYogaFee(int memberid)
    {
        int result=0;
        foreach(MeditationCenter i in memberList)
        {
            if (i.MemberId == memberid)
            {
                i.BMI = i.Weight / (i.Height * i.Height);
                if(i.Goal=="Weight Loss")
                {
                    if(i.BMI>=25 && i.BMI < 30)
                    {
                        result = 2000;
                    }
                    else if(i.BMI>=30 && BMI < 35)
                    {
                        result = 2500;
                    }
                    else if (i.BMI >= 35)
                    {
                        result = 3000;
                    }
                }
                else
                {
                    result = 2500;
                }
            }
        }
        return result;
    }
}