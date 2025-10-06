Looking at your codebase, you're asking about the wholesale and online ordering processes in the e-commerce system. Based on the domain model documentation, I can see both sales.onlineordering and sales.wholesaleordering modules with their respective functionalities model.json:378-520 .

Current Functionalities 
Online Ordering Process 
The online ordering system includes these key capabilities:

Cart Pricing: Price calculation for shopping carts model.json:618-620
Order Placement: Final order submission model.json:612-615
Fulfillment Integration: Automatic order processing after placement OrderPlacedHandler.cs:21-25
Wholesale Ordering Process 
The wholesale system offers more complex business workflows:

Order Creation: Initial order setup model.json:582-585
Order Modification: Adding items to existing orders model.json:573-575
Order Pricing: Quote generation and offer management model.json:593-595
Offer Confirmation: Finalizing negotiated prices model.json:577-580
Order Placement: Final order submission model.json:607-610
Fulfillment Integration: Order processing after placement OrderPlacedHandler.cs:27-31
Process Flow Diagrams 
Online Ordering Flow 
F
OP
CP
RC
F
OP
CP
RC
F
OP
CP
RC
F
OP
CP
RC
Price Cart
Cart Total
Place Order
Online Order Placed Event
Order Confirmation
Wholesale Ordering Flow 
F
OPL
OP
OM
OC
WC
F
OPL
OP
OM
OC
WC
F
OPL
OP
OM
OC
WC
F
OPL
OP
OM
OC
WC
Create Order
Order Draft
Add to Order
Updated Order
Get Offer
Price Quote
Confirm Offer
Confirmed Quote
Place Order
Wholesale Order Placed Event
Order Confirmation
Key Differences 
Online Ordering is streamlined for retail customers:

Simple cart-to-order flow
Immediate pricing
Direct order placement
Wholesale Ordering supports complex B2B scenarios:

Multi-step order building
Quote negotiation process
Order modification capabilities
Separate pricing and placement phases
Proposed Extensions 
Online Ordering Extensions 
Saved Carts: Allow customers to save incomplete carts for later
Quick Reorder: One-click reordering from order history
Bulk Pricing: Volume discounts for large retail orders
Wishlist Integration: Move wishlist items to cart
Wholesale Ordering Extensions 
Approval Workflows: Multi-level approval for large orders
Contract Pricing: Integration with customer-specific pricing agreements
Scheduled Orders: Recurring order automation
Credit Limit Checks: Real-time credit validation during order creation
Order Templates: Reusable order patterns for regular customers
Notes 
The system uses a sophisticated pricing engine that applies different discount strategies based on the sales channel OfferModifiers.cs:18-19 . Both processes integrate with the same fulfillment system but trigger different event handlers for processing . The architecture supports both simple retail transactions and complex B2B negotiations within the same domain model.

Wiki pages you might want to explore:

Documentation System (gitlab.com/szymon.janikowski/ddd-starter-dotnet)