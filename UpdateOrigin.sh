echo "****** Getting ERP Source Update for******"
git remote remove origin
git remote add origin https://tfs2019.akij.net/ERPCollection2/ERP/_git/ERP
git pull
read -t 15 -n 1