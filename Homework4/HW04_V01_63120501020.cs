using System;
using System.Collections.Generic;

public class User
{
    public string Email { get; set; }
    public int RecCount { get; set; }

    public User(string email, int recCount)
    {
        this.Email = email;
        this.RecCount = recCount;
    }
}

public class Coupon
{
    public string Code;
    public string Rank;

    public Coupon(string code, string rank)
    {
        this.Code = code;
        this.Rank = rank;
    }
}

public class CouponGift
{
    public User User;
    public Coupon Coupon;

    public CouponGift(User user, Coupon coupon)
    {
        this.User = user;
        this.Coupon = coupon;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<User> userList = new List<User>();
        userList.Add(new User("john@coldmail.com", 2));
        userList.Add(new User("sam@pmail.co", 16));
        userList.Add(new User("linda1989@oal.com", 1));
        userList.Add(new User("jan1940@ahoy.com", 0));
        userList.Add(new User("mrbig@pmail.co", 25));
        userList.Add(new User("lol@lol.lol", 1));

        List<Coupon> couponList = new List<Coupon>();
        couponList.Add(new Coupon("MAYDISCOUNT", "good"));
        couponList.Add(new Coupon("10PERCENT", "bad"));
        couponList.Add(new Coupon("PROMOTION45", "best"));
        couponList.Add(new Coupon("IHEARTYOU", "bad"));
        couponList.Add(new Coupon("GETADEAL", "best"));
        couponList.Add(new Coupon("ILIKEDISCOUNTS", "good"));
        couponList.Add(new Coupon("10MALL2000", "good"));
        couponList.Add(new Coupon("ONTOP10H4", "best"));
        couponList.Add(new Coupon("KANKUAY", "bad"));


        List<Coupon> bestCouponList = new List<Coupon>();
        List<Coupon> goodCouponList = new List<Coupon>();
        foreach (Coupon coupon in couponList)
        {
            if (coupon.Rank == "best")
            {
                bestCouponList.Add(coupon);
            }
            else if (coupon.Rank == "good")
            {
                goodCouponList.Add(coupon);
            }
        }

        List<User> userWaitForCouponList = new List<User>();
        foreach (User user in userList)
        {
            userWaitForCouponList.Add(user);
        }

        List<CouponGift> couponGiftList = new List<CouponGift>();

        while (userWaitForCouponList.Count > 0)
        {
            User userToGiveCoupon = userWaitForCouponList[0]; //process queue
            List<Coupon> couponListToGive = null;
            if (userToGiveCoupon.RecCount >= 10)
            {
                couponListToGive = bestCouponList;
            }
            else
            {
                couponListToGive = goodCouponList;
            }

            if (couponListToGive.Count > 0)
            {
                Coupon coupon = couponListToGive[0];
                couponGiftList.Add(new CouponGift(userToGiveCoupon, coupon));
                couponListToGive.RemoveAt(0);
            }
            userWaitForCouponList.RemoveAt(0);
        }

        foreach (CouponGift couponGift in couponGiftList)
        {
            Console.WriteLine(
                "User: " + couponGift.User.Email
                + " receive coupon code: "
                + couponGift.Coupon.Code
            );
        }
    }
}