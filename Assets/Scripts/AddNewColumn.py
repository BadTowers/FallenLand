import sys
import re

if len(sys.argv) not in [3,2]:
	print("Usage: AddNewColumn.py <inputFile> (<outputFile> optional, overwrites inputFile if not present)")
	exit(0)
else:
	fileIn = sys.argv[1]
	foutBuff = []
	if len(sys.argv) == 2:
		fileOut = fileIn
	else:
		fileOut = sys.argv[2]
	with open(fileIn,'r') as fin:
		for line in fin.readlines():
			findNum = re.search(r'//[ ]?\(([0-9]+),.+\)',line)
			if findNum:
				foutBuff.append(line.replace('('+findNum.group(1)+',','('+str(int(findNum.group(1))+1)+','))
			else:
				foutBuff.append(line)
	with open(fileOut,'w') as fout:
		for line in foutBuff:
			fout.write(line)