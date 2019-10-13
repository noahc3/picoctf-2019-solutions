.intel_syntax noprefix
	
.global asm2

asm2:
	push   ebp
	mov    ebp,esp
	sub    esp,0x10
	mov    eax,DWORD PTR [ebp+0xc]
	mov    DWORD PTR [ebp-0x4],eax
	mov    eax,DWORD PTR [ebp+0x8]
	mov    DWORD PTR [ebp-0x8],eax
	jmp    asm2+31
	add    DWORD PTR [ebp-0x4],0x1
	add    DWORD PTR [ebp-0x8],0xcc
	cmp    DWORD PTR [ebp-0x8],0x3937
	jle    asm2+20
	mov    eax,DWORD PTR [ebp-0x4]
	leave  
	ret    


