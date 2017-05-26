from os import path, listdir
from wordcloud import WordCloud
from collections import Counter
import jieba

lrc_path = 'lrc-handled'
font_path = 'D:/download/msyh.ttf'

def analysis():
    if not path.exists(lrc_path):
        print('lrc folder not exist')
        return
    
    lrcs = listdir(lrc_path)
    lrc_list = []
    for lrc in lrcs:
        lrc = lrc_path + '/' + lrc
        try:
            # if lrc.startswith('-'):
            #     continue
            lines = open(lrc, encoding='utf-8').readlines()
            for line in lines:
                line = line[line.find(']') + 1:].replace('\n', '')
                if line != '':
                    lrc_list.append(line)
        except Exception as e:
            print(e)
    
    wc = WordCloud(font_path=font_path, width=1000, height=1000, max_words=50)
    frequencies = Counter([w for text in lrc_list for w in jieba.cut(text, cut_all=False) if len(w) > 1])
    img = wc.generate_from_frequencies(frequencies).to_image()
    fn = 'lrc.png'
    img.save(fn)
    a=1

analysis()
