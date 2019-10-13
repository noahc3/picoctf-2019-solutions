.intel_syntax noprefix
	
.global asm1

asm1:
	push   ebp
	mov    ebp,esp
	cmp    DWORD PTR [ebp+0x8],0x37a
	jg     asm1+37
	cmp    DWORD PTR [ebp+0x8],0x345
	jne    asm1+29
	mov    eax,DWORD PTR [ebp+0x8]
	add    eax,0x3
	jmp    asm1+60
	mov    eax,DWORD PTR [ebp+0x8]
	sub    eax,0x3
	jmp    asm1+60
	cmp    DWORD PTR [ebp+0x8],0x5ff
	jne    asm1+54
	mov    eax,DWORD PTR [ebp+0x8]
	sub    eax,0x3
	jmp    asm1+60
	mov    eax,DWORD PTR [ebp+0x8]
	add    eax,0x3
	pop    ebp
	ret    

 
