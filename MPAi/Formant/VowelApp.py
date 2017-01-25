"""
original code from the FormantPlot of which some of the code here is taken from was written by Byron Hui.

Author: Joshua Brudan
upi: jbru239

VowelApp acts as the outer Frame in which the target plot, and vowel buttons are accessed.
"""

from Tkinter import *

import os

from PIL import Image, ImageTk, ImageSequence #For Gif Playing.
import glob
from FormantPlot import FormantPlot
from VowelPlot import VowelPlot
from VowelScorer import VowelScorer
import sys
import thread



DEFAULTHEIGHT = 660 #Height of the MainFrame

FRAMEHEIGHT = 660
FRAMEWIDTH = 680

"""
VowelApp is the application which shows the VowelPlot target system. This is created for a particular voiceType and languageType
Which is defined at the Instantiation of the object. Allows the user to practice the pronouciation of Maori vowel sounds.
"""

class VowelApp:

    def __init__(self):

        #Makes sure parameters are correct and acceptable.
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

        self.vowelScorer = VowelScorer()
        self.id = self.getID(voiceType, langType)

        print 'starting vowel plot for ', voiceType, langType

        #set the default vowel
        self.vowel = 'a:'
        self.previousVowel = 'e:'

        self.initialiseRoot()
        #self.initiatePron()
        self.setUpMenus()
        self.initialiseFrame()

        self.loadVowelPlot(self.id, self.vowel, FRAMEWIDTH, FRAMEHEIGHT)


    """
    Creates thr root for the vowel Plot application. Sets it default behaviour, such as resizable and what to do on exit.
    """
    def initialiseRoot(self):
        self.root = Tk()
        self.root.title("Vowel Plot") #Dont change the title without changing the c# code to end the process.
        self.root.protocol("WM_DELETE_WINDOW", self.quitApp) #Defines the default close operation.
        self.resizeCount=0

        self.root.resizable(False, False) #Allows the window to be resized both verically and horizonally.
        self.root.minsize(510,510)

        self.positionWindowInCentre(self.root, FRAMEWIDTH, FRAMEHEIGHT) #Determines where to place the Frame on the screen.

    def preventResizing(self):
        self.root.resizable(False, False)

    def allowResizing(self):
        self.root.resizable(False, False)

    def bindResizing(self):
        self.bindedFunctionID = self.frame.bind("<Configure>", self.resizeRequest)

    def resizeRequest(self, event):
        self.vowelPlot.onResize(event.width, event.height)

    def unbindResizing(self):
        print "unbinding resizable"
        self.root.unbind("<Configure>", self.bindedFunctionID)


    """
    Set the overall geometry of the application, its position of the screen as well as its size.
    """
    def positionWindowInCentre(self, widget, widgetWidth, widgetHeight):
        widthScreen = self.root.winfo_screenwidth() # gets the width of the screen
        heightScreen = self.root.winfo_screenheight() # gets the height of the screen
        x = (widthScreen/2) - (widgetWidth/2)
        y = (heightScreen/2) - (widgetHeight/2)
        widget.geometry('%dx%d+%d+%d' % (widgetWidth, widgetHeight, x, y)) #Sizes and Centres the application on the screen.

    """
    Sets the icon which apears at the topright of the application.
    """
    def setIcon(self):
        #TODO need an Icon.
        #self.root.iconbitmap(default='fPIcon.ico')
        pass

    """
    Gets the path of the current working directory.
    """
    def getAppPathName(self):
        return os.path.dirname(os.getcwd())


    """
    Converts a voiceType and landType into an idea which simplifies the process of determining which data to be loaded.
    """
    def getID(self, voiceType, langType):
        count = 0
        if(voiceType == 'feminine'):
            count+= 2
        if(langType == 'modern'):
            count+= 1
        return count

    """
    Sets up the menu for the vowel plot application.
    """
    def setUpMenus(self):
        #TODO Currently used as a proof of concept to show the gif player alone side the target.
        #The gif player seems to make the target unstable.

        menubar = Menu(self.root)
        #self.showingPron = False
        #menubar.add_command(label="Toggle: Maori Vowel Pronociation Help", command=self.togglePronHelp)

        self.root.config(menu=menubar)

    """
    Sets up the layout of the Frame in which the target is located.
    """
    def initialiseFrame(self):
        # Grid.rowconfigure(self.root, 0, weight=0)
        # Grid.columnconfigure(self.root, 0, weight=1)
        self.frame = Frame(self.root, bg='white')
        self.frame.pack(fill=BOTH, expand = YES)
        # self.frame.grid(row=0, column=0, sticky=N+S+E+W)

    """
    Loads in the vowel plot for the particular id and vowel. This should only be done while not Recording.
    The buttons which call this method are hidden durinig the recording process.
    """
    def loadVowelPlot(self, id, vowel, width, height):
        self.killFramesChildren()
        self.vowelPlot = VowelPlot(self.frame, self.getAppPathName(), self.root, id, self, self.vowelScorer, vowel, width, height )
        self.vowelPlot.onResize(width,height)
        self.bindResizing()

    """
    Removes the children of the frame which in this case is the Vowel Plot canvas, of which the target and buttons are children of.
    """
    def killFramesChildren(self):
        for widget in self.frame.winfo_children():
            widget.destroy()


#***************************************************************************

    # """
    # The section below proves the functionality for the gif player.
    # Currently it is here to provide a proof of concept.
    #
    # #TODO Migrate this section into its on class.
    # """
    # def displayPronButtons(self):
    #     #TODO This function will potentially become obsolete with Jaydens idea for the media player.
    #     self.pronButtonFrame = Frame(self.root)
    #     self.pronButtonFrame.config(width= 150, bg = 'purple')
    #     self.btnHeight = self.pronButtonFrame.winfo_height()
    #     self.pronButtonFrame.grid(row = 0, column=2, rowspan=1, columnspan = 1, sticky=N+S+E+W)
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
    #     thread.start_new_thread(self.multiThreadAntimate, ("Animator-1", counter))
    #
    #
    # def multiThreadAntimate(self, threadName, counter):
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
    #
    # def toggleAnimate(self):
    #     if(self.animating == True):
    #         self.animating = False
    #     else:
    #         self.animating = True
    #         self.animate(0)
    #

#**************************************************************************



    def mainloop(self):
        self.root.mainloop()

    def quitApp(self):
        print("QUITTING...")
        self.vowelScorer.connectAndSendText()
        self.root.destroy()
