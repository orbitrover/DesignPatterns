## Design Patterns Practice in Asp Net Core 8.0 C# (GoF) design patterns




<div class="flex w-full flex-col gap-1 empty:hidden first:pt-[3px]"><div class="markdown prose w-full break-words dark:prose-invert light"><p>Creating an ASP.NET Core 8 Web API for an e-commerce project that demonstrates all the design patterns mentioned is quite extensive. Each design pattern will serve a specific purpose in the context of the application, such as managing user accounts, processing orders, interacting with products, etc.</p><p>Let's break down the usage of each pattern in the context of the e-commerce project:</p><h3>Project Overview</h3><p><strong>E-Commerce System</strong>:<br>An online store that allows users to browse products, add them to a cart, place orders, and manage user profiles.</p><h4><strong>Creational Patterns</strong></h4><ol><li><strong>Singleton</strong>:<br>Used for a logging service to ensure only one instance handles all log messages.</li><li><strong>Factory Method</strong>:<br>Used for creating different types of payment processors (e.g., Credit Card, PayPal, etc.).</li><li><strong>Abstract Factory</strong>:<br>Used to create families of related objects like product variants or order-related objects.</li><li><strong>Builder</strong>:<br>Used for constructing complex objects such as Order or User profiles step by step.</li><li><strong>Prototype</strong>:<br>Used for creating new instances of an existing product by copying its details.</li></ol><h4><strong>Structural Patterns</strong></h4><ol><li><strong>Adapter</strong>:<br>Used to integrate third-party payment gateway APIs that have different interfaces.</li><li><strong>Decorator</strong>:<br>Used to add additional features to the product (e.g., adding gift wrapping, express shipping).</li><li><strong>Facade</strong>:<br>Used to provide a simplified interface to a complex order processing subsystem.</li><li><strong>Composite</strong>:<br>Used to handle categories and subcategories of products as a tree structure.</li><li><strong>Proxy</strong>:<br>Used to provide a placeholder for the actual product data, loading it on demand (lazy loading).</li></ol><h4><strong>Behavioral Patterns</strong></h4><ol><li><strong>Observer</strong>:<br>Used to notify subscribers (e.g., inventory management system, user notifications) whenever an order is placed.</li><li><strong>Strategy</strong>:<br>Used to select different shipping algorithms based on user preferences or geographic location.</li><li><strong>Command</strong>:<br>Used to encapsulate requests such as placing an order or processing a payment as objects.</li><li><strong>Iterator</strong>:<br>Used to iterate over collections of products, orders, etc., without exposing their underlying structure.</li><li><strong>State</strong>:<br>Used to handle the different states of an order (e.g., Created, Paid, Shipped, Delivered).</li></ol><h3>Code Example Structure</h3><p>I will provide a skeleton for each pattern, integrating them into the e-commerce system. Due to the complexity, let's provide a brief code example for each pattern, and you can extend or refine them as needed for your specific requirements.</p><h4>1. <strong>Singleton Pattern (Logging Service)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">LogService</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">static</span> LogService _instance;
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">static</span> <span class="hljs-keyword">readonly</span> <span class="hljs-built_in">object</span> _lock = <span class="hljs-keyword">new</span> <span class="hljs-built_in">object</span>();

    <span class="hljs-function"><span class="hljs-keyword">private</span> <span class="hljs-title">LogService</span>()</span> { }

    <span class="hljs-keyword">public</span> <span class="hljs-keyword">static</span> LogService Instance
    {
        <span class="hljs-keyword">get</span>
        {
            <span class="hljs-keyword">lock</span> (_lock)
            {
                <span class="hljs-keyword">if</span> (_instance == <span class="hljs-literal">null</span>)
                {
                    _instance = <span class="hljs-keyword">new</span> LogService();
                }
                <span class="hljs-keyword">return</span> _instance;
            }
        }
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Log</span>(<span class="hljs-params"><span class="hljs-built_in">string</span> message</span>)</span>
    {
        <span class="hljs-comment">// Log to a file, database, etc.</span>
        Console.WriteLine(message);
    }
}
</code></div></div></pre><h4>2. <strong>Factory Method (Payment Processors)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">abstract</span> <span class="hljs-keyword">class</span> <span class="hljs-title">PaymentProcessor</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">abstract</span> <span class="hljs-keyword">void</span> <span class="hljs-title">ProcessPayment</span>(<span class="hljs-params"><span class="hljs-built_in">decimal</span> amount</span>)</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">CreditCardProcessor</span> : <span class="hljs-title">PaymentProcessor</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">void</span> <span class="hljs-title">ProcessPayment</span>(<span class="hljs-params"><span class="hljs-built_in">decimal</span> amount</span>)</span>
    {
        <span class="hljs-comment">// Implement credit card payment processing</span>
        Console.WriteLine(<span class="hljs-string">$"Processed credit card payment of <span class="hljs-subst">{amount}</span>"</span>);
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">PayPalProcessor</span> : <span class="hljs-title">PaymentProcessor</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">void</span> <span class="hljs-title">ProcessPayment</span>(<span class="hljs-params"><span class="hljs-built_in">decimal</span> amount</span>)</span>
    {
        <span class="hljs-comment">// Implement PayPal payment processing</span>
        Console.WriteLine(<span class="hljs-string">$"Processed PayPal payment of <span class="hljs-subst">{amount}</span>"</span>);
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">PaymentProcessorFactory</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">static</span> PaymentProcessor <span class="hljs-title">GetPaymentProcessor</span>(<span class="hljs-params"><span class="hljs-built_in">string</span> type</span>)</span>
    {
        <span class="hljs-keyword">switch</span> (type)
        {
            <span class="hljs-keyword">case</span> <span class="hljs-string">"CreditCard"</span>:
                <span class="hljs-keyword">return</span> <span class="hljs-keyword">new</span> CreditCardProcessor();
            <span class="hljs-keyword">case</span> <span class="hljs-string">"PayPal"</span>:
                <span class="hljs-keyword">return</span> <span class="hljs-keyword">new</span> PayPalProcessor();
            <span class="hljs-literal">default</span>:
                <span class="hljs-keyword">throw</span> <span class="hljs-keyword">new</span> ArgumentException(<span class="hljs-string">"Invalid payment processor type"</span>);
        }
    }
}
</code></div></div></pre><h4>3. <strong>Abstract Factory (Order-Related Objects)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IOrderFactory</span>
{
    <span class="hljs-function">IOrder <span class="hljs-title">CreateOrder</span>()</span>;
    <span class="hljs-function">IShipping <span class="hljs-title">CreateShipping</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">StandardOrderFactory</span> : <span class="hljs-title">IOrderFactory</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> IOrder <span class="hljs-title">CreateOrder</span>()</span> =&gt; <span class="hljs-keyword">new</span> StandardOrder();
    <span class="hljs-function"><span class="hljs-keyword">public</span> IShipping <span class="hljs-title">CreateShipping</span>()</span> =&gt; <span class="hljs-keyword">new</span> StandardShipping();
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">PremiumOrderFactory</span> : <span class="hljs-title">IOrderFactory</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> IOrder <span class="hljs-title">CreateOrder</span>()</span> =&gt; <span class="hljs-keyword">new</span> PremiumOrder();
    <span class="hljs-function"><span class="hljs-keyword">public</span> IShipping <span class="hljs-title">CreateShipping</span>()</span> =&gt; <span class="hljs-keyword">new</span> ExpressShipping();
}
</code></div></div></pre><h4>4. <strong>Builder Pattern (Complex Object Creation - Order)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">OrderBuilder</span>
{
    <span class="hljs-keyword">private</span> Order _order = <span class="hljs-keyword">new</span> Order();

    <span class="hljs-function"><span class="hljs-keyword">public</span> OrderBuilder <span class="hljs-title">AddProduct</span>(<span class="hljs-params">Product product</span>)</span>
    {
        _order.Products.Add(product);
        <span class="hljs-keyword">return</span> <span class="hljs-keyword">this</span>;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> OrderBuilder <span class="hljs-title">SetCustomer</span>(<span class="hljs-params">Customer customer</span>)</span>
    {
        _order.Customer = customer;
        <span class="hljs-keyword">return</span> <span class="hljs-keyword">this</span>;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> OrderBuilder <span class="hljs-title">SetShippingAddress</span>(<span class="hljs-params"><span class="hljs-built_in">string</span> address</span>)</span>
    {
        _order.ShippingAddress = address;
        <span class="hljs-keyword">return</span> <span class="hljs-keyword">this</span>;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> Order <span class="hljs-title">Build</span>()</span>
    {
        <span class="hljs-keyword">return</span> _order;
    }
}
</code></div></div></pre><h4>5. <strong>Prototype Pattern (Product Cloning)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">abstract</span> <span class="hljs-keyword">class</span> <span class="hljs-title">ProductPrototype</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">abstract</span> ProductPrototype <span class="hljs-title">Clone</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">Product</span> : <span class="hljs-title">ProductPrototype</span>
{
    <span class="hljs-keyword">public</span> <span class="hljs-built_in">string</span> Name { <span class="hljs-keyword">get</span>; <span class="hljs-keyword">set</span>; }
    <span class="hljs-keyword">public</span> <span class="hljs-built_in">decimal</span> Price { <span class="hljs-keyword">get</span>; <span class="hljs-keyword">set</span>; }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> ProductPrototype <span class="hljs-title">Clone</span>()</span>
    {
        <span class="hljs-keyword">return</span> (ProductPrototype)<span class="hljs-keyword">this</span>.MemberwiseClone();
    }
}
</code></div></div></pre><h4>6. <strong>Adapter Pattern (Third-Party Payment Gateway)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IPaymentGateway</span>
{
    <span class="hljs-function"><span class="hljs-keyword">void</span> <span class="hljs-title">MakePayment</span>(<span class="hljs-params"><span class="hljs-built_in">decimal</span> amount</span>)</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">ThirdPartyPaymentService</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Pay</span>(<span class="hljs-params"><span class="hljs-built_in">decimal</span> amount</span>)</span>
    {
        <span class="hljs-comment">// Payment processing</span>
        Console.WriteLine(<span class="hljs-string">$"Paid <span class="hljs-subst">{amount}</span> using third-party service"</span>);
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">PaymentGatewayAdapter</span> : <span class="hljs-title">IPaymentGateway</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> ThirdPartyPaymentService _thirdPartyPaymentService;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">PaymentGatewayAdapter</span>(<span class="hljs-params">ThirdPartyPaymentService thirdPartyPaymentService</span>)</span>
    {
        _thirdPartyPaymentService = thirdPartyPaymentService;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">MakePayment</span>(<span class="hljs-params"><span class="hljs-built_in">decimal</span> amount</span>)</span>
    {
        _thirdPartyPaymentService.Pay(amount);
    }
}
</code></div></div></pre><h4>7. <strong>Decorator Pattern (Additional Product Features)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IProduct</span>
{
    <span class="hljs-function"><span class="hljs-built_in">string</span> <span class="hljs-title">GetDescription</span>()</span>;
    <span class="hljs-function"><span class="hljs-built_in">decimal</span> <span class="hljs-title">GetPrice</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">BasicProduct</span> : <span class="hljs-title">IProduct</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">string</span> <span class="hljs-title">GetDescription</span>()</span> =&gt; <span class="hljs-string">"Basic Product"</span>;
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">decimal</span> <span class="hljs-title">GetPrice</span>()</span> =&gt; <span class="hljs-number">50</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">GiftWrapDecorator</span> : <span class="hljs-title">IProduct</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> IProduct _product;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">GiftWrapDecorator</span>(<span class="hljs-params">IProduct product</span>)</span>
    {
        _product = product;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">string</span> <span class="hljs-title">GetDescription</span>()</span> =&gt; _product.GetDescription() + <span class="hljs-string">", Gift Wrapped"</span>;
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">decimal</span> <span class="hljs-title">GetPrice</span>()</span> =&gt; _product.GetPrice() + <span class="hljs-number">5</span>;
}
</code></div></div></pre><h4>8. <strong>Facade Pattern (Order Processing Subsystem)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">OrderFacade</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> OrderService _orderService;
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> PaymentService _paymentService;
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> ShippingService _shippingService;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">OrderFacade</span>()</span>
    {
        _orderService = <span class="hljs-keyword">new</span> OrderService();
        _paymentService = <span class="hljs-keyword">new</span> PaymentService();
        _shippingService = <span class="hljs-keyword">new</span> ShippingService();
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">PlaceOrder</span>(<span class="hljs-params">Order order, PaymentDetails paymentDetails</span>)</span>
    {
        _orderService.ProcessOrder(order);
        _paymentService.ProcessPayment(paymentDetails);
        _shippingService.ShipOrder(order);
    }
}
</code></div></div></pre><h4>9. <strong>Composite Pattern (Category Hierarchy)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">ICategoryComponent</span>
{
    <span class="hljs-function"><span class="hljs-keyword">void</span> <span class="hljs-title">Display</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">Category</span> : <span class="hljs-title">ICategoryComponent</span>
{
    <span class="hljs-keyword">public</span> <span class="hljs-built_in">string</span> Name { <span class="hljs-keyword">get</span>; <span class="hljs-keyword">set</span>; }
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> List&lt;ICategoryComponent&gt; _subCategories = <span class="hljs-keyword">new</span> List&lt;ICategoryComponent&gt;();

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Add</span>(<span class="hljs-params">ICategoryComponent category</span>)</span> =&gt; _subCategories.Add(category);
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Remove</span>(<span class="hljs-params">ICategoryComponent category</span>)</span> =&gt; _subCategories.Remove(category);
    
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Display</span>()</span>
    {
        Console.WriteLine(<span class="hljs-string">$"Category: <span class="hljs-subst">{Name}</span>"</span>);
        <span class="hljs-keyword">foreach</span> (<span class="hljs-keyword">var</span> subCategory <span class="hljs-keyword">in</span> _subCategories)
        {
            subCategory.Display();
        }
    }
}
</code></div></div></pre><h4>10. <strong>Proxy Pattern (Lazy Loading of Product Data)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IProductData</span>
{
    <span class="hljs-function"><span class="hljs-built_in">string</span> <span class="hljs-title">GetProductDetails</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">RealProductData</span> : <span class="hljs-title">IProductData</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-built_in">string</span> _productDetails;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">RealProductData</span>()</span>
    {
        <span class="hljs-comment">// Simulate expensive operation</span>
        _productDetails = <span class="hljs-string">"Detailed product information"</span>;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">string</span> <span class="hljs-title">GetProductDetails</span>()</span> =&gt; _productDetails;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">ProductDataProxy</span> : <span class="hljs-title">IProductData</span>
{
    <span class="hljs-keyword">private</span> RealProductData _realProductData;
    
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">string</span> <span class="hljs-title">GetProductDetails</span>()</span>
    {
        <span class="hljs-keyword">if</span> (_realProductData == <span class="hljs-literal">null</span>)
        {
            _realProductData = <span class="hljs-keyword">new</span> RealProductData();
        }
        <span class="hljs-keyword">return</span> _realProductData.GetProductDetails();
    }
}
</code></div></div></pre><h4>11. <strong>Observer Pattern (Order Event Notification)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IObserver</span>
{
    <span class="hljs-function"><span class="hljs-keyword">void</span> <span class="hljs-title">Update</span>(<span class="hljs-params">Order order</span>)</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">InventoryObserver</span> : <span class="hljs-title">IObserver</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Update</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-comment">// Update inventory</span>
        Console.WriteLine(<span class="hljs-string">"Inventory updated for order: "</span> + order.Id);
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">EmailNotificationObserver</span> : <span class="hljs-title">IObserver</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Update</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-comment">// Send email notification</span>
        Console.WriteLine(<span class="hljs-string">"Email sent for order: "</span> + order.Id);
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">OrderSubject</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> List&lt;IObserver&gt; _observers = <span class="hljs-keyword">new</span> List&lt;IObserver&gt;();

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Attach</span>(<span class="hljs-params">IObserver observer</span>)</span> =&gt; _observers.Add(observer);
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Detach</span>(<span class="hljs-params">IObserver observer</span>)</span> =&gt; _observers.Remove(observer);

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Notify</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-keyword">foreach</span> (<span class="hljs-keyword">var</span> observer <span class="hljs-keyword">in</span> _observers)
        {
            observer.Update(order);
        }
    }
}
</code></div></div></pre><h4>12. <strong>Strategy Pattern (Shipping Cost Calculation)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IShippingStrategy</span>
{
    <span class="hljs-function"><span class="hljs-built_in">decimal</span> <span class="hljs-title">CalculateShippingCost</span>(<span class="hljs-params">Order order</span>)</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">StandardShippingStrategy</span> : <span class="hljs-title">IShippingStrategy</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">decimal</span> <span class="hljs-title">CalculateShippingCost</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-keyword">return</span> <span class="hljs-number">10</span>; <span class="hljs-comment">// Flat rate</span>
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">ExpressShippingStrategy</span> : <span class="hljs-title">IShippingStrategy</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">decimal</span> <span class="hljs-title">CalculateShippingCost</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-keyword">return</span> <span class="hljs-number">25</span>; <span class="hljs-comment">// Flat rate for express shipping</span>
    }
}
</code></div></div></pre><h4>13. <strong>Command Pattern (Encapsulate Orders)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">ICommand</span>
{
    <span class="hljs-function"><span class="hljs-keyword">void</span> <span class="hljs-title">Execute</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">PlaceOrderCommand</span> : <span class="hljs-title">ICommand</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> Order _order;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">PlaceOrderCommand</span>(<span class="hljs-params">Order order</span>)</span>
    {
        _order = order;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Execute</span>()</span>
    {
        <span class="hljs-comment">// Logic to place the order</span>
        Console.WriteLine(<span class="hljs-string">$"Order <span class="hljs-subst">{_order.Id}</span> placed."</span>);
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">CancelOrderCommand</span> : <span class="hljs-title">ICommand</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> Order _order;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">CancelOrderCommand</span>(<span class="hljs-params">Order order</span>)</span>
    {
        _order = order;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Execute</span>()</span>
    {
        <span class="hljs-comment">// Logic to cancel the order</span>
        Console.WriteLine(<span class="hljs-string">$"Order <span class="hljs-subst">{_order.Id}</span> cancelled."</span>);
    }
}
</code></div></div></pre><h4>14. <strong>Iterator Pattern (Product Collection Iteration)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IIterator</span>
{
    <span class="hljs-function"><span class="hljs-built_in">bool</span> <span class="hljs-title">HasNext</span>()</span>;
    <span class="hljs-function">Product <span class="hljs-title">Next</span>()</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">ProductIterator</span> : <span class="hljs-title">IIterator</span>
{
    <span class="hljs-keyword">private</span> <span class="hljs-keyword">readonly</span> List&lt;Product&gt; _products;
    <span class="hljs-keyword">private</span> <span class="hljs-built_in">int</span> _position = <span class="hljs-number">0</span>;

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">ProductIterator</span>(<span class="hljs-params">List&lt;Product&gt; products</span>)</span>
    {
        _products = products;
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-built_in">bool</span> <span class="hljs-title">HasNext</span>()</span> =&gt; _position &lt; _products.Count;

    <span class="hljs-function"><span class="hljs-keyword">public</span> Product <span class="hljs-title">Next</span>()</span> =&gt; _products[_position++];
}
</code></div></div></pre><h4>15. <strong>State Pattern (Order State Management)</strong></h4><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">interface</span> <span class="hljs-title">IOrderState</span>
{
    <span class="hljs-function"><span class="hljs-keyword">void</span> <span class="hljs-title">Handle</span>(<span class="hljs-params">Order order</span>)</span>;
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">OrderCreatedState</span> : <span class="hljs-title">IOrderState</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Handle</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-comment">// Handle created state</span>
        Console.WriteLine(<span class="hljs-string">$"Order <span class="hljs-subst">{order.Id}</span> is in created state."</span>);
        order.SetState(<span class="hljs-keyword">new</span> OrderPaidState());
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">OrderPaidState</span> : <span class="hljs-title">IOrderState</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Handle</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-comment">// Handle paid state</span>
        Console.WriteLine(<span class="hljs-string">$"Order <span class="hljs-subst">{order.Id}</span> is paid."</span>);
        order.SetState(<span class="hljs-keyword">new</span> OrderShippedState());
    }
}

<span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">OrderShippedState</span> : <span class="hljs-title">IOrderState</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Handle</span>(<span class="hljs-params">Order order</span>)</span>
    {
        <span class="hljs-comment">// Handle shipped state</span>
        Console.WriteLine(<span class="hljs-string">$"Order <span class="hljs-subst">{order.Id}</span> is shipped."</span>);
        order.SetState(<span class="hljs-keyword">new</span> OrderDeliveredState());
    }
}
</code></div></div></pre><h3>Putting It All Together</h3><p>To implement these patterns in an ASP.NET Core 8 Web API project:</p><ol><li><strong>Controllers</strong>: Implement controllers to manage user requests (e.g., <code>OrderController</code>, <code>ProductController</code>).</li><li><strong>Services</strong>: Use services to handle business logic (e.g., <code>OrderService</code>, <code>PaymentService</code>).</li><li><strong>Repositories</strong>: Interact with the database to retrieve and persist data (e.g., <code>ProductRepository</code>, <code>OrderRepository</code>).</li></ol><p><strong>Example: Startup Configuration</strong></p><pre><div class="dark bg-gray-950 rounded-md border-[0.5px] border-token-border-medium"><div class="flex items-center relative text-token-text-secondary bg-token-main-surface-secondary px-4 py-2 text-xs font-sans justify-between rounded-t-md"><span>csharp</span><div class="flex items-center"><span class="" data-state="closed"><button class="flex gap-1 items-center"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="icon-sm"><path fill-rule="evenodd" clip-rule="evenodd" d="M7 5C7 3.34315 8.34315 2 10 2H19C20.6569 2 22 3.34315 22 5V14C22 15.6569 20.6569 17 19 17H17V19C17 20.6569 15.6569 22 14 22H5C3.34315 22 2 20.6569 2 19V10C2 8.34315 3.34315 7 5 7H7V5ZM9 7H14C15.6569 7 17 8.34315 17 10V15H19C19.5523 15 20 14.5523 20 14V5C20 4.44772 19.5523 4 19 4H10C9.44772 4 9 4.44772 9 5V7ZM5 9C4.44772 9 4 9.44772 4 10V19C4 19.5523 4.44772 20 5 20H14C14.5523 20 15 19.5523 15 19V10C15 9.44772 14.5523 9 14 9H5Z" fill="currentColor"></path></svg>Copy code</button></span></div></div><div class="overflow-y-auto p-4" dir="ltr"><code class="!whitespace-pre hljs language-csharp"><span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">Startup</span>
{
    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">ConfigureServices</span>(<span class="hljs-params">IServiceCollection services</span>)</span>
    {
        services.AddSingleton&lt;LogService&gt;();
        services.AddScoped&lt;OrderService&gt;();
        services.AddScoped&lt;PaymentService&gt;();
        services.AddScoped&lt;ShippingService&gt;();
        services.AddControllers();
        services.AddDbContext&lt;ApplicationDbContext&gt;(options =&gt;
            options.UseSqlServer(Configuration.GetConnectionString(<span class="hljs-string">"DefaultConnection"</span>)));
    }

    <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">void</span> <span class="hljs-title">Configure</span>(<span class="hljs-params">IApplicationBuilder app, IWebHostEnvironment env</span>)</span>
    {
        <span class="hljs-keyword">if</span> (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =&gt;
        {
            endpoints.MapControllers();
        });
    }
}
</code></div></div></pre><p>This skeleton provides a solid starting point to demonstrate how each design pattern could be implemented in an ASP.NET Core Web API project for an e-commerce application. You can expand on this by implementing the actual business logic, connecting to a real database, handling errors, and more.</p></div></div>
