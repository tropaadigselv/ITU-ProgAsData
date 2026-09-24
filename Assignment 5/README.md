# 6.4
## (i)
The type rule tree for ´´´ let f x = 1 in f f end ´´´ looks like this:

<img width="987" height="262" alt="billede" src="https://github.com/user-attachments/assets/c78374fa-0fac-4bcd-ac12-640abab400a3" />

The type of f is polymorphic since it returns the x that is given.

## (ii)
The type rule tree for ´´´ let f x = if x<10 then 42 else f(x+1) in f 20 end ´´´ looks like this:

<img width="1082" height="325" alt="billede" src="https://github.com/user-attachments/assets/db1b8d46-ad97-42c0-9956-a76ec405c00c" />

The type of f is not polymorphic since the if statement returns an integer. 
