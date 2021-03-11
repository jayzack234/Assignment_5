using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Assignment_5.Infrastructure;
namespace Assignment_5.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public virtual void AddItem(Project product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public virtual void RemoveLine(Project product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public virtual void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}