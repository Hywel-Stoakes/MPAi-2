"""
Rebuild of FormantPlot
Previous Author: Byron Hui
upi bhui004
Much of the code has been reused from Byrons original Python code.

Author: Joshua Brudan
upi: jbru239

FormantApp acts as the outer Frame in which the Plotter and button screens are viewed from.
Created to add further abstraction to the FormantPlot.
"""

from Tkinter import *

import os
import sys

from PIL import Image, ImageTk, ImageSequence #For Gif Playing.
import glob
from FormantPlot import FormantPlot

SIZERATIO = 1.6180339887499 #GoldenRatio

DEFAULTHEIGHT = 625 #Height of the MainFrame

FRAMEHEIGHT = DEFAULTHEIGHT
FRAMEWIDTH = round(DEFAULTHEIGHT * SIZERATIO) #Calculates the correct width from height.

class FormantApp:

    """
    Constructor for the FormantApp.
    Creates and initialises the FormantApp.
    """
    def __init__(self):

        if len(sys.argv) == 3:
            if sys.argv[1].lower() == 'masculine' or sys.argv[1].lower() == 'feminine':
                voiceType = sys.argv[1].lower()
            else:
                exceptString = 'Invalid VoiceType: '+sys.argv[1]+', Must be masculine or feminine'
                raise Exception(exceptString)
                self.quitPlot()
            if sys.argv[2].lower() == 'heritage' or sys.argv[2].lower() == 'modern':
                langType = sys.argv[2].lower()
            else:
                exceptString = 'Invalid LanguageType: '+sys.argv[2]+', Must be heritage or modern.'
                raise Exception(exceptString)
                self.quitPlot()
        else:
            exceptString = 'Invalid number of arguments , requires 3, ' + (str)(len(sys.argv)) + ' given.'
            try:
                raise Exception(exceptString)
            except Exception as e:
                print e
                # self.quitPlot()
                #TODO remove the testing code below...
                print 'for Testing, setting you to masculine and modern'
                voiceType = 'masculine'
                langType = 'heritage'


        print "Creating Formant Plot for :", voiceType, langType

        self.id = self.getId(voiceType, langType)

        self.initialiseRoot()

        self.setIcon()

        #self.setUpButtons()

        #Grid.rowconfigure(self.root, 0, weight=1)
        #Grid.columnconfigure(self.root, 0, weight=1)
        self.frame = Frame(self.root)
        self.root.minsize(680,400)
        #self.frame.grid(row=0, column=0, sticky=N+S+E+W)

        #self.initiatePron()
        self.setUpMenus()

        #Intial Background value
        self.currentBGindex = 2

        #Grid.rowconfigure(self.root, 0, weight=1)
        #Grid.columnconfigure(self.root, 0, weight=1)
        self.frame = Frame(self.root, bg='white')

        self.frame.pack(fill=BOTH, expand=YES)


        self.loadFormantPlot(self.id)


    """
    Gets the id of the formantPlot from the langType and voiceType.
    """
    def getId(self, voiceType,langType):
        plotID = 0
        if(voiceType == 'feminine'):
            plotID += 2
        if(langType == 'modern'):
            plotID += 1
        return plotID

    """
    Initialises the Root of FormantApp as an Tk application.
    Sets the name of the application which is used by the c# to end the process.
    """
    def initialiseRoot(self):
        self.root = Tk()
        self.root.title("Formant Plot") #Dont change the title without changing the c# code to end the process.
        self.root.protocol("WM_DELETE_WINDOW", self.quitPlot) #Defines the default close operation.
        self.root.resizable(True, True) #Allows the window to be resized both verically and horizonally.
        self.positionWindowInCentre(self.root, FRAMEWIDTH, FRAMEHEIGHT) #Determines where to place the Frame on the screen.
        import time
        import struct


        #TODO This code below is the code needed to connect to the pipping server created in C#
        # and used to read and write messages. Currently just just test code. needs writing properly
        # f = open(r'\\.\pipe\NPtest', 'r+b', 0)
        # i = 1
        #
        # s = 'Message[{0}]'.format(i)
        # i += 1
        #
        # f.write(struct.pack('I', len(s)) + s)   # Write str length and str
        # f.seek(0)                               # EDIT: This is also necessary
        # print 'Wrote:', s
        #
        # n = struct.unpack('I', f.read(4))[0]    # Read str length
        # s = f.read(n)                           # Read str
        # f.seek(0)                               # Important!!!
        # print 'Read:', s

    """
    gets the icon of the application.
    """
    def setIcon(self):
        #TODO need an Icon.
        #self.root.iconbitmap(default='fPIcon.ico')
        pass

    """
    Creates the default geometry of the application frame.
    Centres the frame, and sets it to the default size.
    """
    def positionWindowInCentre(self, widget, widgetWidth, widgetHeight):
        widthScreen = self.root.winfo_screenwidth() # gets the width of the screen
        heightScreen = self.root.winfo_screenheight() # gets the height of the screen

        x = (widthScreen/2) - (widgetWidth/2)
        y = (heightScreen/2) - (widgetHeight/2)

        widget.geometry('%dx%d+%d+%d' % (widgetWidth, widgetHeight, x, y)) #Sizes and Centres the application on the screen.


    # """
    # sets up the buttons which are used to acces the formant plot for the various genders/ages.
    # buttons currently replace the tabs
    # """
    # def setUpButtons(self):
    #     Grid.rowconfigure(self.root, 0, weight=1)
    #     Grid.columnconfigure(self.root, 0, weight=1)
    #     self.frame = Frame(self.root)
    #
    #     self.frame.grid(row=0, column=0, sticky=N+S+E+W)
    #     font = ('Arial','30')
    #
    #     buttonLabels = ("Senior Male", "Young Male", "Senior Female", "Young Female")
    #     count=0
    #
    #     for colIndex in range(0,2):
    #         Grid.columnconfigure(self.frame, colIndex, weight=1)
    #         for rowIndex in range(0,2):
    #             Grid.rowconfigure(self.frame, rowIndex, weight=1)
    #             btn = Button(self.frame, text=buttonLabels[count], font=font, relief='groove', bd=5, command= lambda i=count: self.loadFormantPlot(i))
    #             btn.grid(row=rowIndex, column=colIndex, sticky=N+S+E+W)
    #             count += 1

    """
    Set up the menubar and its elements.
    """
    def setUpMenus(self):
        menubar = Menu(self.root)
        self.showingPron = False
        filemenu = Menu(menubar, tearoff=0)
        optionsMenu = Menu(menubar)
        self.filemenu = filemenu
        menubar.add_cascade(label="File", menu=filemenu)
        self.saveCom = filemenu.add_command(label="Save Current Audio", command=self.popup)
        self.loadCom = filemenu.add_command(label="load a Audio File", command=lambda: self.loadAudioFile())

        #menubar.add_command(label="Toggle: Maori Vowel Pronociation Help", command=self.togglePronHelp)
        #menubar.add_command(label="Back", command=self.goBack)

        menubar.add_cascade(label="Options", menu=optionsMenu)
        optionsMenu.add_command(label='toggleLines', command= self.toggleLines)
        optionsMenu.add_command(label='toggleLoadedPlots', command = self.toggleLoadedPlots)
        optionsMenu.add_command(label='BackGroundNoise: Normal', command = self.toggleBackgroundNoise)
        self.optionsMenu = optionsMenu
        self.vowelType = 'long'

        self.root.config(menu=menubar)


    def rec(self):
        self.formantPlot.record()

    def sto(self):
        self.formantPlot.stop()

    """
    Requests the current formant plot to save its current recording.
    """
    def save(self):
        self.formantPlot.save()

    """
    gets the current working directory.
    """
    def getAppPathName(self):
        return os.path.dirname(os.getcwd())

#*************************************************************************************************************
    """
    Creates a new formant plot to be loaded, by deleteing all the children of the mainFrame which is the parent of the formantPlots.
    """
    def loadFormantPlot(self, plotID):
        for widget in self.frame.winfo_children():
            widget.destroy()
        mainFrame = self.frame

        path = self.getAppPathName()
        mainFrame.pack()



        self.formantPlot = FormantPlot(mainFrame, path, self.root, plotID, self)
        mainFrame.bind("<Configure>", self.resizeRequest)

        self.formantPlot.resize(mainFrame.winfo_width(), mainFrame.winfo_height())

    """
    resizeRequest, asks the formant Plot to resize
    """
    def resizeRequest(self, event):
        self.formantPlot.resize(event.width, event.height)

    """
    Toggles long or short vowels, used for testing, and determining the scales which are needed by the mon and dip data.
    """
    def toggleVowelType(self):

        if self.formantPlot.isRecording == False:
            if self.vowelType == 'long':
                self.vowelType = 'short'
            else:
                self.vowelType = 'long'
            self.loadFormantPlot(self.id)
        else:
            print "Recording therefore cannot toggle Vowel."



    """
    Requests the current formant plot to load in a audio file onto the plot.
    """
    def loadAudioFile(self):
        self.formantPlot.loadAudioFile()

    """
    The application has been resized someway and we need the formant plot to follow suit.
    """
    def onResize(self, event):
        #TODO
        pass
#*************************************************************************************************************
    """
    Requests the current formant plot to toggle Lines.
    """
    def toggleLines(self):
        self.formantPlot.toggleLines()

    """
    Requests the current formant plot to toggle the loaded in plots (yellow)
    """
    def toggleLoadedPlots(self):
        self.formantPlot.toggleLoadedPlots()

    """
    Requests the current formant plot to change its function that handles the removing of background noise.
    """
    def toggleBackgroundNoise(self):
        #TODO This needs to be a lot more simple. Maybe select a default value and only let it be changed though settings.
        self.currentBGindex += 1

        bgIntensities = [ "BackGroundNoise: None", "BackGroundNoise: Little",  "BackGroundNoise: Normal", "BackGroundNoise: Moderate", "BackGroundNoise: Extreme"]

        if self.currentBGindex >= len(bgIntensities):
            self.currentBGindex = 0

        labelName = bgIntensities[self.currentBGindex]
        self.optionsMenu.entryconfigure(3, label=labelName)

        self.formantPlot.toggleBackgroundNoise(self.currentBGindex)


#*************************************************************************************************************
    # """
    # Displays the canvas which holds the buttons for the gif Player.
    # """
    # def displayPronButtons(self):
    #     #TODO This function will potentially become obsolete with Jaydens idea for the media player.
    #     self.pronButtonFrame = Frame(self.root)
    #     self.pronButtonFrame.config(width= 150, bg = 'purple')
    #     self.btnHeight = self.pronButtonFrame.winfo_height()
    #     self.pronButtonFrame.grid(row = 0, column=3, rowspan=1, columnspan = 1, sticky=N+S+E+W)
    #     fileEnd = "Vowel.gif"
    #     count = 0
    #     for file in os.listdir("gifs"):
    #         if file.endswith(fileEnd):
    #             count+=1
    #     rowIndex = 0
    #     for file in os.listdir("gifs"):
    #         if file.endswith(fileEnd):
    #             label = file[0:(len(file)-len(fileEnd))]
    #             Grid.rowconfigure(self.pronButtonFrame, rowIndex)
    #             btn = Button(self.pronButtonFrame, text=label, relief='groove', bd=5, command= lambda lab=label: self.pronButtonHandler(lab))
    #             btn.grid(row=rowIndex, column=0, sticky=N+S+E+W)
    #             rowIndex += 1
    #     Grid.rowconfigure(self.pronButtonFrame, rowIndex)
    #     btn = Button(self.pronButtonFrame, text="<-", relief='groove', bd=5, command= lambda lab=label: self.pronButtonHandler("hide"))
    #     btn.grid(row=rowIndex, column=0, sticky=E+W)
    #     btn.config(height=self.btnHeight/count)
    #     rowIndex += 1
    #
    #
    #
    # def togglePronHelp(self):
    #     self.pronHelp("menu")
    #
    # """
    # creates the basic off state of the gif player.
    # """
    # def initiatePron(self):
    #     self.animating = False
    #     self.pronActive = False
    #     self.previousVowel = "menu"
    #
    # def pronButtonHandler(self, vowel):
    #     if(vowel == "hide"):
    #         for widget in self.pronButtonFrame.winfo_children():
    #             widget.destroy()
    #         self.pronButtonFrame.grid_forget()
    #     else:
    #         self.pronHelp(vowel)
    #         self.displayPronButtons
    #
    # def hidePronHelp(self):
    #     self.animating = False;
    #
    #     self.sequence = []
    #     self.pronCanvas.config(height=0, width = 0, bg = 'white')
    #     self.positionWindowInCentre(self.root, FRAMEWIDTH, FRAMEHEIGHT)
    #     self.positionWindowInCentre(self.root, FRAMEWIDTH, FRAMEHEIGHT)
    #     Grid.columnconfigure(self.frame, 2, weight=0)
    #
    # def pronHelp(self, vowel):
    #
    #     if self.animating == True:
    #         self.animating = False
    #     if(vowel == "menu"):
    #         if(self.pronActive == True):
    #             self.hidePronHelp()
    #             self.pronActive = False
    #         else:
    #             self.displayPronButtons()
    #     else:
    #         if(vowel == self.previousVowel):
    #             if(self.pronActive):
    #                 self.hidePronHelp()
    #                 self.pronActive = False
    #             else:
    #                 self.displayPronHelp(vowel)
    #         else:
    #             if(self.pronActive == True):
    #                 self.hidePronHelp()
    #                 self.pronActive = False
    #                 self.displayPronHelp(vowel)
    #                 self.pronActive = True
    #             else:
    #                 self.displayPronHelp(vowel)
    #                 self.pronActive = True
    #     self.previousVowel = vowel
    #
    # def displayPronHelp(self, vowel):
    #
    #     self.pronActive = True
    #
    #     self.pronCanvas = Canvas(self.root)
    #     self.pronCanvas.config(width= 600, bg = 'black')
    #     self.pronCanvas.grid(row = 0, column=2, rowspan=2, columnspan = 1, sticky=N+S+E+W)
    #
    #     self.pronCanvas.bind("<Button-1>", self.toggleAnimate)
    #
    #     self.positionWindowInCentre(self.root, FRAMEWIDTH+600, FRAMEHEIGHT)
    #
    #     fileName = 'gifs/' + vowel + 'Vowel.gif'
    #     self.sequence = [ImageTk.PhotoImage(img.resize(((500),(500))))
    #                         for img in ImageSequence.Iterator(
    #                             Image.open(
    #                                 fileName
    #                                 )
    #                                 )]
    #     self.image = self.pronCanvas.create_image(300,300, image=self.sequence[0])
    #     font = ('Arial','17')
    #     self.vowelBox = self.pronCanvas.create_rectangle(0,0,40,40, tag='vowelBox', fill='red')
    #     self.vowelBox = self.pronCanvas.create_text(20,20, text=(vowel.lower()),font=font, tag='vowelBox', fill='black')
    #     self.toggleAnimate()
    #     self.animate(0)
    #
    # def animate(self, counter):
    #     if not self.animating:
    #         # destroy the current sequence
    #         self.sequence = []
    #         return
    #     else:
    #         self.pronCanvas.itemconfig(self.image, image=self.sequence[counter])
    #
    #         try:
    #             self.pronActive = True
    #             self.root.after(100, lambda: self.animate(  ((counter+1) % (len(self.sequence)-4))))
    #         except IndexError:
    #             pass

    def goBack(self):

        for widget in self.frame.winfo_children():
            widget.destroy()
        self.setUpButtons()

    def toggleAnimate(self):
        if(self.animating == True):
            self.animating = False
        else:
            self.animating = True
            self.animate(0)

    """
    mainLoop of the FormantApp.
    """
    def mainloop(self):
        self.root.mainloop()

    """
    QuitPlot is called when the application is closed.
    Handles the quiting process.
    """
    def quitPlot(self):
        self.root.destroy()



#*******************************************************************************

#Below is rought saving method, simplify the saving process, currently Proof of concept
# requires a lot of tidying up. maybe its own file
    def popup(self):
        width = 100
        height = 100
        self.top=Toplevel(self.root)
        x= (self.root.winfo_screenwidth()/2 - width/2)
        y= (self.root.winfo_screenheight()/2- height/2)

        self.top.geometry('%dx%d+%d+%d' % (width,height,x,y))
        self.l=Label(self.top,text="Write file name:")
        self.l.pack()
        self.e=Entry(self.top)
        self.e.pack(ipady=4)
        self.b=Button(self.top,text='  Save  ',command=self.save)
        self.b.pack()
        self.root.wait_window(self.top)

    def overwritePopup(self):
        width = 100
        height = 100
        self.top2=Toplevel(self.root)
        x= (self.root.winfo_screenwidth()/2 - width/2)
        y= (self.root.winfo_screenheight()/2- height/2)

        self.top2.geometry('%dx%d+%d+%d' % (width,height,x,y))
        self.l2=Label(self.top2,text="File already Exists\nDo you want to overwrite?")
        self.l2.pack()
        self.b2=Button(self.top2,text='  Yes  ',command=self.overwrite)
        self.btn=Button(self.top2,text='  No, Rename  ',command=self.renameFile)

        self.b2.pack()
        self.btn.pack()
        self.root.wait_window(self.top2)

    def load(self):
        self.formantPlot.loadAudioFile()

    def renameFile(self):
        self.top.destroy()
        self.top2.destroy()
        self.popup()


    def overwrite(self):
        saveName = self.dirName+"/"+self.fileName+".wav"
        f = open(saveName, 'w')
        self.formantPlot.recordedAudio.write(saveName, start=0, end=-1)
        f.close()
        self.top2.destroy()


    def save(self):
        self.dirName = "userAudio"
        self.fileName = self.e.get()
        dirName = self.dirName
        fileName = self.fileName

        if fileName.isalnum():
            fileName = fileName + ".wav"

            if os.path.isdir(dirName):
                pass
            else:
                os.makedirs(dirName)
            if not(os.path.exists(dirName+"/"+fileName)):
                f = open(dirName+"/"+fileName, 'w')
                self.formantPlot.recordedAudio.write(dirName+"/"+fileName, start=0, end=-1)
                f.close()

            else:
                self.overwritePopup()
        else:
            self.l.config(label="Invalid Name, can only contain:\na-z, 0:9")
            self.top.destroy()
            self.popup()



        self.top.destroy()



# ******************************************************************************
