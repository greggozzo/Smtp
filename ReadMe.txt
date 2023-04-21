
SMTP SES interface

Created by: Greg Gozzo


To use credentials downloaded from SES in .csv file, specify the path of the file without "" around it.

Everything else should be pretty self explanitory.

Make sure your ses smtp credentials match the region you are chosing and that you are sending From an identity in that Region.

To use Delegate sending (Using an identity from another account), you will need the ARN for the identity that you are using. 
Credentials for the delegate sender(sending account), must match the region of the identity ARN you are using from teh Identity owner account.
Sending Authorization policy must be in place on the identity in the identity owner account to allow the delegate account to send.