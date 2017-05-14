from pymongo import MongoClient
import json

client = MongoClient()
coll = client['WechatHistory']['chengyu']
try:
    # fn = open('chengyu.json', encoding='utf-8').read()	
    # fn = '[' + fn + ']'
    # res = json.loads(fn)	#chengyu.json 是从mongodb导出的，因为每一行有回车，不能直接转
    cys = open('chengyu.txt', encoding='utf-8').readlines()
except Exception as ex:
    print(ex)
for cy in cys:
    item = cy.rstrip('').rstrip('\n').split(' ')
    if len(item) == 5 and len(item[0]) == 4:
        if len(list(coll.find({'cy': item[0]}))) != 1:
            print(item[0])
            coll.insert({'cy': item[0], 'first': item[1],'second': item[2], 'third': item[3], 'last': item[-1]})
    else:
        print(cy)
a=1