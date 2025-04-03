class Solution:
    def isValid(self, s: str) -> bool:
        if not s:
            return True
        if len(s) == 1:
            return False

        stack = []
        hashMap = {')': '(', '}': '{', ']': '['}

        for p in s:
            if p not in hashMap: # its an opening bracket
                stack.append(p)
            else: # its a closing bracket
                if len(stack) == 0:
                    return False
                elif hashMap[p] == stack[-1]:
                    stack.pop()
                else:
                    return False

        return True if not stack else False