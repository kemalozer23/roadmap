class Solution:
    def isValid(self, s: str) -> bool:
        stack = []
        hashMap = {')': '(', '}': '{', ']': '['}

        for p in s:
            if p not in hashMap: # its an opening bracket
                stack.append(p)
            else: # its a closing bracket
                if stack.count == 0:
                    return False
                elif hashMap[p] == stack[-1]:
                    stack.pop()

        return True if not stack else False