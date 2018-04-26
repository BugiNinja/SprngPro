
        Dim sDialog
        Dim iDialogStartLines()
        Dim arrDialog
        Dim triggers
    Function GetTriggers()
        Const ForReading = 1

            ' Specify the file name.
            strFile = "Triggers.txt"

            ' Open the file for reading.
            Set objFSO = CreateObject("Scripting.FileSystemObject")
            Set objFile = objFSO.OpenTextFile(strFile, ForReading)

            'Read the full file
            strData = objFile.ReadAll

             
            arrTrigger = split(strData, vbLf)
            triggers = UBound(arrTrigger) - 1
            call SetTriggers(triggers)
            ' Clean up.
            objFile.Close
    End Function
    Function AddTrigger()
        Const ForWriting = 2
            MsgBox "tallenna ja kaynnista uudestaan jotta uusi triggeri nakyy. ps. muista myos paivittaa triggeri referenssi taulukko"
            ' Specify the file name.
            strFile = "Triggers.txt"

            ' Open the file for writing.
            Set objFSO = CreateObject("Scripting.FileSystemObject")
            Set objFile = objFSO.OpenTextFile(strFile, ForWriting)
            
            i = 0
            
            Do While triggers + 1 >= i
                objFile.WriteLine i
                i = i + 1
            loop
            ' Clean up.
            objFile.Close


    End Function
    Function SayHello()
        MsgBox "Hello"
        Const ForReading = 1

            ' Specify the file name.
            strFile = "Dialogues.txt"

            ' Open the file for reading.
            Set objFSO = CreateObject("Scripting.FileSystemObject")
            Set objFile = objFSO.OpenTextFile(strFile, ForReading)

            'Read the full file
            strData = objFile.ReadAll

             
            arrDialog = split(strData, vbLf)
            
            ' Find the position of the string for which we are looking
            i = 0
            si = 0
            Do While UBound(arrDialog) > i
                
                strPosition = instr(1, arrDialog(i), "#")
                if strPosition = 1 then
                redim preserve iDialogStartLines(si+1)
                iDialogStartLines(si) = i
                si = si + 1
                end if
                
                i = i + 1
            loop
            
            
            call SetDialog(arrDialog)
            call SetStartLines(iDialogStartLines)

            ' Clean up.
            objFile.Close
      End Function
    Function saveFile(arrNewDialogAsString, dialogIndex, IsNewDialog)
            Const ForReading = 1
            arrNewDialog= split(arrNewDialogAsString, ",")
            i = 0
             Do While UBound(arrNewDialog) > i
             arrNewDialog(i) = Replace(arrNewDialog(i), "--", ",")
             i = i + 1
             loop
            ' Specify the file name.
            strFile = "output\Dialogues.txt"

            ' Open the file for reading.
            Set objFSO = CreateObject("Scripting.FileSystemObject")
            Set objFile = objFSO.OpenTextFile(strFile, ForReading)

            'Read the full file
            strData = objFile.ReadAll

             
            arrDialog = split(strData, vbLf)
            if arrDialog(UBound(arrDialog)) = "" then
            redim preserve arrDialog(UBound(arrDialog) - 1)
            end if
            
            i = 0
            si = 0
            Do While UBound(arrDialog) > i
                
                strPosition = instr(1, arrDialog(i), "#")
                if strPosition = 1 then
                redim preserve iDialogStartLines(si+1)
                iDialogStartLines(si) = i
                si = si + 1
                end if
                
                i = i + 1
            loop



            arrD = arrDialog

            if IsNewDialog then

            i = 0
            si = uBound(arrD) + 1
            ti = 0
            redim preserve arrD(si + UBound(arrNewDialog))
            Do While UBound(arrNewDialog) >= (ti)
                        arrD(si) = arrNewDialog(ti)
                        si = si + 1
                        ti = ti + 1
            loop
            i = 0
            si = 0
            
            Do While UBound(arrD) > i
                
                strPosition = instr(1, arrD(i), "#")
                if strPosition = 1 then
                redim preserve iDialogStartLines(si+1)
                iDialogStartLines(si) = i
                si = si + 1
                end if
                
                i = i + 1
            loop
            call SetStartLines(iDialogStartLines)

            else

            i = 0
            si = 0
            ti = 0
            
            Do While UBound(arrDialog) >= i
                if UBound(arrD) < si then
                redim preserve arrD(si+1)
                end if
                arrD(si) = arrDialog(i)
                
                i = i + 1
                si = si + 1
                
                if i = iDialogStartLines(dialogIndex) then
                   
                    Do While UBound(arrNewDialog) >= (ti)
                        if UBound(arrD) < si then
                        redim preserve arrD(si)
                        end if
                        arrD(si) = arrNewDialog(ti)
                        si = si + 1
                        ti = ti + 1
                    loop
                    if UBound(iDialogStartLines) = (dialogIndex + 1) then
                        
                        i = (UBound(arrDialog)+1)
                       
                    else 
                         i = iDialogStartLines(dialogIndex + 1)
                    end if
                end if
            loop
            end if
            

            ' Clean up.
            objFile.Close
            Const ForWriting = 2

            ' Specify the file name.
            strFile = "output\Dialogues.txt"

            ' Open the file for writing.
            Set objFSO = CreateObject("Scripting.FileSystemObject")
            Set objFile = objFSO.OpenTextFile(strFile, ForWriting)
            
            i = 0
            Do While UBound(arrD) >= i
                objFile.WriteLine arrD(i)
                i = i + 1
            loop
            ' Clean up.
            objFile.Close

            
            



    End Function
    Function readFile()
            Const ForReading = 1

            ' Specify the file name.
            strFile = "output\Dialogues.txt"

            ' Open the file for reading.
            Set objFSO = CreateObject("Scripting.FileSystemObject")
            Set objFile = objFSO.OpenTextFile(strFile, ForReading)

            'Read the full file
            strData = objFile.ReadAll

             
            arrDialog = split(strData, vbLf)
            
            ' Find the position of the string for which we are looking
            i = 0
            si = 0
            Do While UBound(arrDialog) > i
                
                strPosition = instr(1, arrDialog(i), "#")
                if strPosition = 1 then
                redim preserve iDialogStartLines(si+1)
                iDialogStartLines(si) = i
                si = si + 1
                end if
                
                i = i + 1
            loop
            
            GetTriggers()
            
            call SetDialog(arrDialog)
            call SetStartLines(iDialogStartLines)
            
            ' Clean up.
            objFile.Close
    End Function
    