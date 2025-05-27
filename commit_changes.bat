@echo off
echo Adding all changes...
git add .

echo Committing changes...
git commit -m "Implemented service layer with proper dependency injection:
- Added MealService implementation
- Updated MemberService implementation
- Configured Unity DI in Global.asax.cs
- Fixed interface implementations"

echo Pushing to master branch...
git push origin master

echo Done!
pause 