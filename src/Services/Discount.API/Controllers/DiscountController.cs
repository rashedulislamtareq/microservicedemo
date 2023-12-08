namespace Discount.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DiscountController : BaseController
{
    private readonly ICouponRepository _couponRepository;

    public DiscountController(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetDiscount(string productId)
    {
        try
        {
            var coupon = await _couponRepository.GetDiscount(productId);
            return CustomResult(coupon);
        }
        catch (Exception ex)
        {
            return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscount([FromBody] Coupon coupon)
    {
        try
        {
            var response = await _couponRepository.CreateDiscount(coupon);
            if (response)
                return CustomResult("Coupon Saved Successfully.", coupon);
            return CustomResult("Coupon Save failed.", System.Net.HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
    {
        try
        {
            var response = await _couponRepository.UpdateDiscount(coupon);
            if (response)
                return CustomResult("Coupon Updated Successfully.", coupon);
            return CustomResult("Coupon Update Failed.", System.Net.HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscount(string productId)
    {
        try
        {
            var response = await _couponRepository.DeleteDiscount(productId);
            if (response)
                return CustomResult("Coupon Deleted Successfully.");
            return CustomResult("Coupon Delete Failed.", System.Net.HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
        }
    }
}
