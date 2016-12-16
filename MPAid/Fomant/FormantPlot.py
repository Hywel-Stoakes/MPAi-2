from Tkinter import *
from tkSnack import *
import tkSnack
import ttk #unsure of purpose currently
from LoudnessMeter import *
import tkFileDialog

import os
import SoundProcessing
from time import sleep
import thread

SIZERATIO = 1.6180339887499 #GoldenRatio

DEFAULTHEIGHT = 580 #Height of the MainFrame

PLOTHEIGHT = DEFAULTHEIGHT
PLOTWIDTH = round(DEFAULTHEIGHT * SIZERATIO) #Calculates the correct width from height.

XSHIFT = 75
YSHIFT = 55

XOFFSET =100
YOFFSET=500

SCALEDOWN = 3
class FormantPlot:

    def __init__(self, parent, path, root, id, formApp):
        self.root = root
        self.formApp = formApp
        self.parent = parent
        self.path = path
        self.id = id

        if id == 0 or id == 1:
            self.gender = "male"
        else:
            self.gender = "female"


        #plot Setup:
        self.updateRate = 30
        self.setupPlot()

        self.drawGoldStandardMonophthongs(True)

        self.createKey()
        self.createAxis()

        self.prevX = 0
        self.prevY = 0



        # sound Setup:
        self.initialiseSounds()
        self.formantRadius = 2
        self.formantColour = 'black'
        self.isRecording = False
        self.lineHiddens = False
        self.loadedPlots= False

        self.backgroundNoiseDistance = 50
        self.count  =0

        self.notStopped = False




    def setupPlot(self):
        #Plot
        self.formantPlotFrame = self.parent
        self.formantPlotCanvas = Canvas(self.formantPlotFrame, height=PLOTHEIGHT-60, width=PLOTWIDTH, bg='white')
        self.formantPlotCanvas.grid(row=0 ,column=0, sticky=N+S+E+W)
        self.formantPlotCanvas.bind("<Button-1>", self.callback)

        #Creates the loudnessMeter on the formant plot canvas.
        self.loudnessMeter = LoudnessMeter(self.formantPlotCanvas,YSHIFT)

        #Control frame
        self.formantPlotControlFrame = Frame(self.formantPlotFrame)
        self.formantPlotControlFrame.grid(row=1,column=0,sticky='w'+'e',columnspan=2)

        self.formantPlotControlFrame.columnconfigure(0, minsize=round(PLOTWIDTH/3.1))
        self.formantPlotControlFrame.columnconfigure(1, minsize=round(PLOTWIDTH/3.1))
        self.formantPlotControlFrame.columnconfigure(2, minsize=round(PLOTWIDTH/3.1))
        #Buttons
        self.recButton = Button(self.formantPlotControlFrame, text='Record', command=self.record)
        self.recButton.grid(row=1,column=0,sticky='w'+'e'+'n'+'s',padx=10)

        self.stopButton = Button(self.formantPlotControlFrame, text='Stop', command=self.stop, state='disabled')
        self.stopButton.grid(row=1,column=1,sticky='w'+'e'+'n'+'s',padx=10)

        self.clearScreenButton = Button(self.formantPlotControlFrame, text='Clear Plot', command=self.clear, state='normal')
        self.clearScreenButton.grid(row=1,column=2,sticky='w'+'e'+'n'+'s')

        boxWidth= 150
        font = ('Arial','15')

        x1 = (PLOTWIDTH/2) - (boxWidth/2)
        y1 = 2
        x2 = (PLOTWIDTH/2) + (boxWidth/2)
        y2 = 32
        self.recordingBox = self.formantPlotCanvas.create_rectangle(x1,y1,x2,y2, tag='Recording', fill='red', outline='black')
        self.recordingBoxText = self.formantPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='Recording', text='Recording.',font=font, fill='black')
        self.formantPlotCanvas.itemconfig('Recording', state='hidden')

        x1 = (PLOTWIDTH/2) - (boxWidth/2) + boxWidth
        y1 = 2
        x2 = (PLOTWIDTH/2) + (boxWidth/2) + boxWidth
        y2 = 32
        self.recordingBox = self.formantPlotCanvas.create_rectangle(x1,y1,x2,y2, tag='Loudness', outline='black')
        self.recordingBoxText = self.formantPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='toLoud', text='Too Loud.',font=font, fill='black')
        self.recordingBoxText = self.formantPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='toQuiet', text='Too Quiet.',font=font, fill='black')
        self.formantPlotCanvas.itemconfig('toLoud', state = 'hidden')
        self.formantPlotCanvas.itemconfig('toQuiet', state = 'hidden')
        self.formantPlotCanvas.itemconfig('Loudness', state='hidden')

    def createKey(self):
        font = ('Arial','13')
        radius = 4
        x=PLOTWIDTH-160
        y=15
        self.formantPlotCanvas.create_text(x+80, y, text="Key:", tag='legend', font=font)
        self.formantPlotCanvas.create_oval(x-radius,y+20-radius,x+radius,y+20+radius,tag='legend',fill='black')
        self.formantPlotCanvas.create_text(x+80,y+20,text='Recorded Vowels',tag='legend',font=font)
        self.formantPlotCanvas.create_oval(x-radius,y+40-radius,x+radius,y+40+radius,tag='legend',fill='yellow')
        self.formantPlotCanvas.create_text(x+80,y+40,text='Loaded Vowels',tag='legend',font=font)

        self.formantPlotCanvas.create_line(x-15, 0, x-15, y+50, tag='legend')
        self.formantPlotCanvas.create_line(x-15, y+50, PLOTWIDTH+50, y+50, tag='legend')

    def createAxis(self):
        self.formantPlotCanvas.create_line(XSHIFT,PLOTHEIGHT-YSHIFT,PLOTWIDTH,PLOTHEIGHT-YSHIFT, tags="formantAxes")
        for y in range(0,PLOTHEIGHT-YSHIFT,20):
            self.formantPlotCanvas.create_line(XSHIFT-8,0+y,XSHIFT,0+y, tags="formantAxes")

        self.formantPlotCanvas.create_line(XSHIFT,0,XSHIFT,PLOTHEIGHT-YSHIFT, tags="formantAxes")
        for x in range(0,900,50):
            self.formantPlotCanvas.create_line(XSHIFT+x,PLOTHEIGHT-YSHIFT,XSHIFT+x,PLOTHEIGHT-YSHIFT+8)

        self.formantPlotCanvas.create_text((XSHIFT+PLOTWIDTH)/2, PLOTHEIGHT-YSHIFT+25,text = "Tongue Position",font = ('Arial','13'), tags="formantAxes")
        self.formantPlotCanvas.create_text(XSHIFT+22, PLOTHEIGHT-YSHIFT+20,text = "Front",font = ('Arial','13'), tags="formantAxes")
        self.formantPlotCanvas.create_text(PLOTWIDTH-30, PLOTHEIGHT-YSHIFT+20,text = "Back",font = ('Arial','13'), tags="formantAxes")
        self.formantPlotCanvas.create_text(XSHIFT/2, (PLOTHEIGHT-YSHIFT)/2,text = "Mouth",font = ('Arial','13'), tags="formantAxes")
        self.formantPlotCanvas.create_text(XSHIFT/2, ((PLOTHEIGHT-YSHIFT)/2)+20,text = "Openness",font = ('Arial','13'), tags="formantAxes")
        self.formantPlotCanvas.create_text(XSHIFT/2, PLOTHEIGHT-YSHIFT-20,text = "Open",font = ('Arial','13'), tags="formantAxes")
        self.formantPlotCanvas.create_text(XSHIFT/2, 20,text = "Closed",font = ('Arial','13'), tags="formantAxes")



    def drawGoldStandardMonophthongs(self, toFill):
        id = self.id

        (xScale, xShift, yScale, yShift) = self.getPlotScaleInfo(id)
        data = self.goldStandardMonophthongs(id)

        std = 1

        for f1mean, f1sd, f2mean, f2sd, vowel in data:
            font = ('Arial','20','bold')
            x1 = (f2mean-std*f2sd)*xScale - xShift
            y1 = (f1mean-std*f1sd)*yScale - yShift
            x2 = (f2mean+std*f2sd)*xScale - xShift
            y2 = (f1mean+std*f1sd)*yScale - yShift
            if toFill:
                currentOval = self.formantPlotCanvas.create_oval(x1,y1,x2,y2, outline='black', tag='ellipses', fill='#ffffff', activefill='#e3c5d6')
            else:
                currentOval = self.formantPlotCanvas.create_oval(x1,y1,x2,y2, outline='black', tag='ellipses',activefill='#e3c5d6')

            ovalText= self.formantPlotCanvas.create_text(f2mean*xScale-xShift,f1mean*yScale-yShift,fill='red',font=font,tag='ellipses', text=vowel)
            self.formantPlotCanvas.tag_bind(currentOval, "<Button-1>", lambda event, v = vowel: self.ovalPressed(event,v))
            self.formantPlotCanvas.tag_bind(ovalText, "<Button-1>", lambda event, v = vowel: self.ovalPressed(event,v))

        #creating the overlap
        for f1mean, f1sd, f2mean, f2sd, vowel in data:
            x1 = (f2mean-std*f2sd)*xScale-xShift
            y1 = (f1mean-std*f1sd)*yScale-yShift
            x2 = (f2mean+std*f2sd)*xScale-xShift
            y2 = (f1mean+std*f1sd)*yScale-yShift
            currentOval = self.formantPlotCanvas.create_oval(x1,y1,x2,y2, outline='black', tag='ellipses')
            self.formantPlotCanvas.tag_bind(currentOval, "<Button-1>", lambda event, v = vowel: self.ovalPressed(event,v))

    def redrawPlotInfo(self):
        self.drawGoldStandardMonophthongs(False)
        self.createAxis()
        self.createKey()



    def ovalPressed(self, event, vowel):
        self.formApp.pronHelp(vowel)

    def getPlotScaleInfo(self, id):
        if id == 0:
            xScale=1.5
            xShift=400
            yScale=2
            yShift=100
        elif id == 1:
            xScale=1.5
            xShift=400
            yScale=2.7
            yShift=300
        elif id == 2:
            xScale=1.2
            xShift=130
            yScale=1.8
            yShift=130
        elif id ==3:
            xScale=1.5
            xShift=330
            yScale=2.7
            yShift=300

        return (xScale, xShift, yScale, yShift)

    def goldStandardMonophthongs(self, id):
        path = self.path
        if id == 0:
            data = self.appendData(path,'data\maori\monDataMale.txt')
        elif id == 1:
            data = self.appendData(path,'data\maori\monDataMaleYoung.txt')
        elif id == 2:
            data = self.appendData(path,'data\maori\monDataFemale.txt')
        elif id == 3:
            data = self.appendData(path,'data\maori\monDataFemaleYoung.txt')
        return data

    def appendData(self, pat, str):
        MonophthongDataPath = os.path.join(pat, str)
        MonophthongFile = open(MonophthongDataPath,'r')
        MonophthongData = []
        #Code from ywan478 2010 SoftEng206 Project
        #Load in the monophthong data for males
        for monophthongDataLine in MonophthongFile:
            monophthongDataLine = monophthongDataLine.split()
            #F1 mean and standard deviation
            monophthongDataLine[0]= (int(float(monophthongDataLine[0]))/SCALEDOWN)
            monophthongDataLine[1]= (int(float(monophthongDataLine[1]))/SCALEDOWN)
            #F2 mean and standard deviation
            monophthongDataLine[2]= PLOTWIDTH - (int(float(monophthongDataLine[2]))/SCALEDOWN) + XSHIFT + XOFFSET
            monophthongDataLine[3]= (int(float(monophthongDataLine[3]))/SCALEDOWN)
            MonophthongData.append(monophthongDataLine)
            #End code from ywan478
        return MonophthongData

#***********************************************************************************************************
# Sound

    '''
    Creates the Snack Sound objects used in the formant plot.
    '''
    def initialiseSounds(self):
        tkSnack.initializeSnack(self.root)
        self.recordedAudio = Sound()
        self.soundCopy = Sound()
        self.loadedAudio = Sound()


    """
    Plot Fomrants takes a sound file and plots the last formant in the file.
    """
    def plotFormants(self, sound):
        #Gets the probablity of sound being a voice for the last formant in the sound file. (false means last formant, true means all formants)
        probabilityOfVoicing = SoundProcessing.getProbabilityOfVoicing(sound,False)

        if probabilityOfVoicing == 1.0:

            formant = SoundProcessing.getFormants(sound,self.id,False)

            #Only plot the latest formants of the sound if there's a good chance that it is the user speaking instead of background noise.
            if formant != None:
                (xScale, xShift, yScale, yShift) = self.getPlotScaleInfo(self.id)
                #GetUser default or user defined colour and radius for the individual formants
                radius = self.formantRadius
                color = self.formantColour
                yPreScale = formant[0]/SCALEDOWN
                xPreScale = PLOTWIDTH - (formant[1]/SCALEDOWN) + XSHIFT + XOFFSET

                y = yPreScale * yScale - yShift
                x = xPreScale * xScale - xShift


                self.count += 1
                #Only plot of the Points are on the Grid. They can go over the axis though.
                if (x > 0 ) and ( y < PLOTHEIGHT):
                    distance = (((x-self.prevX) ** 2 + (y-self.prevY) ** 2) ** (0.5))

                    if( distance < self.backgroundNoiseDistance) and distance > 0:

                        self.formantPlotCanvas.create_oval(x-radius,y-radius,x+radius,y+radius, fill=color, tags="userformants")

                    self.prevX = x
                    self.prevY = y




                if not self.isRecording:
                    if formant != None:
                        pass

    """
    record is called whent eh record button is pressed it starts recording the users sounds
    and makes the formant plot react accordingly.
    """
    def record(self):

        self.notStopped = True
        self.recordedAudio.record()
        self.Recording = True
        self.recButton.config(state='disabled')
        self.stopButton.config(state='normal')
        self.clearScreenButton.config(state='disabled')
        self.formantPlotCanvas.itemconfig('Recording', state='normal')

        #self.root.after(self.updateRate,self.updateAllCanvases)
        self.count2 = 0
        thread.start_new_thread(self.multiThreadUpdateCanvas, ("Thread-1", self.notStopped))



    def multiThreadUpdateCanvas(self, threadName, notStopped):
        try:
            while self.notStopped:
                print "Not stopped"
                self.count2+=1
                self.soundCopy.copy(self.recordedAudio)
                SoundProcessing.crop(self.soundCopy)
                self.plotFormants(self.soundCopy)
                if self.count2 % 10 == 0:
                    self.updateLoudnessMeter(self.soundCopy)

        except Exception:
            import traceback
            print traceback.format_exc()

    def stop(self):
        self.notStopped = False
        self.formantPlotCanvas.itemconfig('Recording', state='hidden')
        self.loudnessMeter.clearMeter
        self.recordedAudio.stop()
        self.recButton.config(state='normal')
        self.stopButton.config(state='disabled')
        self.clearScreenButton.config(state='normal')

        self.Recording = False
        self.root.after(200 ,self.removeLoudness)
        self.count = 0

    def removeLoudness(self):
        self.loudnessMeter.clearMeter()
        self.formantPlotCanvas.itemconfig('toLoud', state = 'hidden')
        self.formantPlotCanvas.itemconfig('toQuiet', state = 'hidden')
        self.formantPlotCanvas.itemconfig('Loudness', state='hidden')



    def clear(self):
        self.formantPlotCanvas.delete('userformants')

    def changeColor(self):
        self.formantColour = 'pink'

    '''
        Update the formant plot and loudness meter if the user is still recording.
    '''
    def updateAllCanvases(self):
        self.soundCopy.copy(self.recordedAudio)
        SoundProcessing.crop(self.soundCopy)
        self.plotFormants(self.soundCopy)

        self.updateLoudnessMeter(self.soundCopy)
        if self.Recording:

            self.updateAllCanvases()


    def updateLoudnessMeter(self, sound):
        try:
            self.loudnessMeter.updateMeter(sound)

        except IndexError:
            pass

    def playAudioFile(self):
        self.loadedAudio.play()

    def loadAudioFile(self):
        self.formantPlotCanvas.delete("loadedLines")
        self.formantPlotCanvas.delete("loadedPlots")

        self.loadedPlots = True
        filename = tkFileDialog.askopenfilename(initialdir="userAudio")
        radius = self.formantRadius
        self.formantPlotCanvas.delete('loadedformants')

        self.loadedAudio.config(load=filename)

        import wave
        import contextlib
        fname = filename
        with contextlib.closing(wave.open(fname,'r')) as f:
            frames = f.getnframes()

            rate = f.getframerate()
            duration = float(frames) / float(rate)

        loadedFormants = SoundProcessing.getFormants(self.loadedAudio,self.gender,True)
        probabilityOfVoicingList = SoundProcessing.getProbabilityOfVoicing(self.loadedAudio,True)
        self.formantPlotCanvas.delete('loadedformants')

        sleeptime =  float(duration)/len(probabilityOfVoicingList)

        thread.start_new_thread(self.multiThreadLoader, ("Thread-2", sleeptime, probabilityOfVoicingList, loadedFormants ))


        #thread.start_new_thread(self.multiThreadPlayer, ("Thread-1", self.loadedAudio))



    def multiThreadPlayer(self, threadName, sound):
        sound.play()


    '''
    multiThreadLoader plots the formant plots onto the formant plot using an additional thread to allow the application not to freeze
    especially if the audio file is very large.
    '''
    def multiThreadLoader(self, threadName, delay, probabilityOfVoicingList, loadedFormants) :
        self.count = 0
        try:
            radius = self.formantRadius
            for i in range(0,len(loadedFormants)):


                probabilityOfVoicing = probabilityOfVoicingList[i]
                if probabilityOfVoicing == 1.0:
                    formant = loadedFormants[i]
                    latestF1 = formant[0]/SCALEDOWN
                    latestF2 = PLOTWIDTH - (formant[1]/SCALEDOWN) + XSHIFT + XOFFSET

                    (xScale, xShift, yScale, yShift) = self.getPlotScaleInfo(self.id)

                    if latestF2 > XSHIFT and latestF1 < PLOTHEIGHT-YSHIFT:


                        self.prevplotted = True
                        self.prevX = latestF2*xScale - xShift
                        self.prevY = latestF1*yScale - yShift
                        break
            for i in range(0,len(loadedFormants)):


                probabilityOfVoicing = probabilityOfVoicingList[i]
                if probabilityOfVoicing == 1.0:
                    formant = loadedFormants[i]
                    latestF1 = formant[0]/SCALEDOWN
                    latestF2 = PLOTWIDTH - (formant[1]/SCALEDOWN) + XSHIFT + XOFFSET

                    (xScale, xShift, yScale, yShift) = self.getPlotScaleInfo(self.id)

                    if latestF2 > XSHIFT and latestF1 < PLOTHEIGHT-YSHIFT:

                        x = latestF2*xScale - xShift
                        y = latestF1*yScale - yShift

                        x1 = x - radius
                        y1 = y - radius
                        x2 = x + radius
                        y2 = y + radius

                        #sleep(delay)


                        if ( (((x-self.prevX) ** 2 + (y-self.prevY) ** 2) ** (0.5)) < self.backgroundNoiseDistance):
                            if(self.prevplotted == True):
                                self.formantPlotCanvas.create_line(self.prevX,self.prevY,x,y, fill='black', tags='loadedLines')
                                pass

                            self.formantPlotCanvas.create_oval(x1,y1,x2,y2, fill='yellow', tags="loadedformants")
                            self.prevplotted = True

                            self.count += 1
                        else:
                            self.prevplotter = False

                        self.prevX = x
                        self.prevY = y

        except Exception:
            import traceback
            print traceback.format_exc()
        self.formantPlotCanvas.itemconfig("loadedLines", state='hidden')
        self.lineHiddens = True

        self.redrawPlotInfo()
        self.count = 0

    def toggleLoadedPlots(self):
        if self.loadedPlots:
            self.formantPlotCanvas.itemconfig("loadedformants", state="hidden")
            self.loadedPlots= False
        else:
            self.formantPlotCanvas.itemconfig("loadedformants", state="normal")
            self.loadedPlots = True


    def toggleLines(self):
        if self.lineHiddens:
            self.formantPlotCanvas.itemconfig("loadedLines", state="normal")
            self.lineHiddens = False
        else:
            self.formantPlotCanvas.itemconfig("loadedLines", state="hidden")
            self.lineHiddens = True

    def toggleBackgroundNoise(self, level):
        if level == 0:
            self.backgroundNoiseDistance = 10000
        elif level == 1:
            self.backgroundNoiseDistance = 100
        elif level == 2:
            self.backgroundNoiseDistance = 50

        elif level == 3:
            self.backgroundNoiseDistance = 30
        else:
            self.backgroundNoiseDistance = 10




    def callback(self, event):
        pass
