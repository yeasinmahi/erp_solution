echo "****** Getting ERP Source Update******"
git remote remove origin
git remote add origin https://tfs2019.akij.net/ERPCollection2/ERP/_git/ERP
echo "****** ERP Source Updated Successfully******"
echo "****** ERP Source Pulling******"
git pull origin master

read -t 15 -n 1
echo "****** ERP Updating upstream url******"
git branch --set-upstream-to=origin/master
read -t 5 -n 1