Feature:buy dress
	
Scenario: Buy a dresses sucessfully using DataTables
    Given that Maria selects the following dresses
      | popularClothes              |
      | Faded Short Sleeve T-shirts |
      #| Printed Dress               |
    When She goes to the cart
    And creates a profile to buy
    Then she should see the message Your order on My Store is complete. as confirmation message
