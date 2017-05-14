import requests
from xml.etree import ElementTree
from urllib.request import urlretrieve
from time import sleep
from os import path

agent = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15007'
header = {"User-Agent": agent}
lrc_path = 'lrc'

def get_song_lrc(song_id):
    song_url = 'http://www.xiami.com/song/playlist/id/{}/object_name/default/object_id/0'.format(song_id)
    r = requests.get(song_url, headers=header)
    root = ElementTree.fromstring(r.text)
    namespace = '{http://xspf.org/ns/0/}'
    track = root.find('{}trackList'.format(namespace))[0]
    song_id = track.find('{}songId'.format(namespace)).text
    # songName = track.find('{}songName'.format(namespace)).text
    lrc_url = track.find('{}lyric'.format(namespace)).text
    urlretrieve(lrc_url, '{}/{}.lrc'.format(lrc_path, song_id))

def get_album_lrc(album_id):
    album_url = 'http://www.xiami.com/song/playlist/id/{}/type/1'.format(album_id)
    r = requests.get(album_url, headers=header)
    root = ElementTree.fromstring(r.text)
    namespace = '{http://xspf.org/ns/0/}'
    tracks = root.find('{}trackList'.format(namespace))
    for track in tracks:
        try:
            song_id = track.find('{}songId'.format(namespace)).text
            song_name = track.find('{}songName'.format(namespace)).text
            lrc_url = track.find('{}lyric'.format(namespace)).text
            file_name = '{}/{}.lrc'.format(lrc_path, song_id)
            if path.exists(file_name):
                continue
            urlretrieve(lrc_url, file_name)
            print('success download {} lrc'.format(song_name))
        except Exception as e:
            print(e)
        sleep(1)

def get_album_lrc_fromFile(xml_file):
    root = ElementTree.parse(xml_file)
    namespace = '{http://xspf.org/ns/0/}'
    tracks = root.find('{}trackList'.format(namespace))
    for track in tracks:
        try:
            song_id = track.find('{}songId'.format(namespace)).text
            song_name = track.find('{}songName'.format(namespace)).text
            lrc_url = track.find('{}lyric'.format(namespace)).text
            file_name = '{}/{}.lrc'.format(lrc_path, song_id)
            if path.exists(file_name):
                continue
            urlretrieve(lrc_url, file_name)
            print('success download {} lrc'.format(song_name))
        except Exception as e:
            print(e)
        sleep(1)    

get_album_lrc_fromFile('1.xml')

albums_id = ['396151', '459960', '1369631477', '2007927693', '2100355547']
for album in albums_id:
    print('downloading album {}'.format(album))
    get_album_lrc(album)
    sleep(3)
print('success download all albums')
a=1
