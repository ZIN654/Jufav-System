# JUFAV SALES AND INVENTORY SYSTEM 

![untitled222](https://github.com/user-attachments/assets/b2556ca2-8a22-40be-afd9-ed7074518047)



## Description
* Version 1.0.1 updated in JULY 24 , 2024
* Developed in : Visual Studio C# 2015
* .Net Framework Version : 4.8.1



> ### Note:
> * Notify each member kapag mag cocommit kayo.
> * Please po pa organize files if nessescary kapag natapos po kayu.
> * Mag cocomit lang po tayo everytime na mahaba po yung natapos nyung progress.
> * Isa isa lang po sana ang mag cocomit.


### How to Clone/Copy this project on your device?

**Method 1**
- Code>Download zip, DONE! :)

**Method 2**
- To get your copy make sure you have Git or github desktop installed on your computer 

- Git link download (Git windows)[https://git-scm.com/downloads].
- Github link download (Git windows)[https://desktop.github.com/download/].

> ### Note:
>  Mas madaling gamitin jan yung Github desktop di katulad sa Git na sa CMD ka mag ooperate sa Github deskop may User interface ka.

Once na matapos madownload paki install na den.

## Using Git
To clone the project your git installation path must be setted in environment variables.allowing your device to use git in CMD.
to set your Git in environment variables.
### Inserting git installation path in Environment Variables
* first step is to locate your installation path in my case it is located at:

  ```
  C:\Program Files\Git
  
  ```
* then locate the folder named **cmd** and dont forget to copy the directory of it.
   ```
  C:\Program Files\Git\cmd
  
  ```
  once you've done that. 
* In the search bar of windows simply type **"edit system environment variables"** or **"Environment Variables"** a new panel will appear named **'System properties'**.
* In the System properties click **Environment Variables** usually at the bottom right of the panel.
* Once you have clicked that a new panel will appear. in this panel locate **Path** in the **System variables** and Click **edit**.
* A new panel will appear then Click **new** and paste your copied path before.

### Using git to Clone,Pull,Push the main project repository ###
to clone this repository use this command. pili ka nalang kung saang folder mo lalagay to:

```
//cmd
git clone https://github.com/ZIN654/JUFAV-System.git

```
### Git basic operations 
> ### Note:
> Before you run git commands in cmd make sure you are in the folder where **.git** folder is existing. usually this folder is hidden so make sure to check the checkbox of **hidden files** in the file explorer.
![image](https://github.com/user-attachments/assets/e3a7b995-367e-48cc-8564-dc06a6f2ac50)
* To know the status of your project. such as updated files,classes and code. execute this in cmd
```
//cmd
git status
```
* To add all updated files use:
```
//cmd
// -A or . to add all files
git add .

// add only one file
git add "define here what file will be added"
```
* To commit your work
```
//cmd
git commit -m "your commit name"
```
### how to Push/Pull in this repo
**Linking our local repo to the Github repository**

- First we should get a reference link to this repository to link our local repository to this github repository so we can push/pull. to do this in project files locate where **.git** is existing and in cmd run:
  
> ### Note:
> Execute this command only once.
  ```
  git remote add origin https://github.com/ZIN654/JUFAV-System.git
  ```

**Push/Pull our current project**
- To push this updates our current repo in github.
```
//cmd
git push -u -f origin
```

- For more information about git go to (Git Official Website)[https://git-scm.com/docs/git]
just type in your cmd `git help` to show some helpful command information.


## Using Github Desktop
After of the installation process log in to git desktop

-then select File>Clone repository 
![image](https://github.com/user-attachments/assets/04b1a1c7-40db-4199-81ed-9b90ec1f89c2)

then choose the URL
![image](https://github.com/user-attachments/assets/3c5b71bd-1523-457e-8a78-74bc69c1fcc2)

**In this two fields :**
The first one is the URL of the repository. in this case use this :
```
ZIN654/JUFAV-System
```
The second is where you define which directory this repository will be cloned.

After that Click clone. and then your done.

## UI Navigating
* The `summary` and `description` refers to the message and title of the commit
![image](https://github.com/user-attachments/assets/5693d5d7-c896-4c0b-86db-4ee86f701fcf)
* The `Current repository` is your local repository.dont change it unless you know what your doing.
* The `Changes` here you can  view each changes of files and codes in you project.
* The `history` Meh.

![image](https://github.com/user-attachments/assets/453d412a-79d6-4033-a84c-2a33343f496d)
* The red circle is where you push/fetch the repository this changes whether your local repository have changes.
* The gree circle is where you can see the changes in your code.
* To push the changes just click `push` push is only available when you commit.

> ### Example  images
> ![image](https://github.com/user-attachments/assets/4b62492b-c8b5-4539-a9d7-918547420def)
> When changes are commited in the local repo you can now push it to the github repository.
> ![image](https://github.com/user-attachments/assets/efadd598-f9b3-4dbb-b4d7-dabc3553078c)


GROUP MEMBERS:
- Klain
- Jezter
- Leslie
- Dion



FINAL DEFENCE NOVEMBER BAHALA NA SI BATMAN.