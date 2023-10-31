# Welcome to the Intune Firewall Troubleshooter

The goal of this project is to help troubleshoot issues related to firewall rules deployed from Microsoft Intune. 

![menu](/images/menu1.png)

Currently the app has 2 features:
- A) View successfully deployed firewall rules from Intune
![local](/images/local1.png)
- B) Manually build out rules to determine if they would be successfully applied
![manual](/images/builder1.png)


Part A design is complete and fully implemented

Part B is partially implemented. It will alert the user to many of the common scenarios that lead to a failed firewall rule. More development is needed to increase the number of checks that it does against the input information


Future ideas to add eventually:
- Enter a policy json and evaluate it
- Create a policy json from the manual builder for upload via Graph
