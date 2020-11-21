;;;======================================================
;;;   Automotive Expert System
;;;
;;;     This expert system diagnoses some simple
;;;     problems with a car.
;;;
;;;     CLIPS Version 6.3 Example
;;;
;;;     To execute, merely load, reset and run.
;;;======================================================

;;****************
;;* DEFFUNCTIONS *
;;****************

(deffunction ask-question (?question $?allowed-values)
   (printout t ?question)
   (bind ?answer (read))
   (if (lexemep ?answer) 
       then (bind ?answer (lowcase ?answer)))
   (while (not (member$ ?answer ?allowed-values)) do
      (printout t ?question)
      (bind ?answer (read))
      (if (lexemep ?answer) 
          then (bind ?answer (lowcase ?answer))))
   ?answer)

(deffunction yes-or-no-p (?question)
   (bind ?response (ask-question ?question yes no y n))
   (if (or (eq ?response yes) (eq ?response y))
       then yes 
       else no))

;;;***************
;;;* QUERY RULES *
;;;***************

(defrule determine-budget-state-low ""
	(not (budget-low ?))
	(not (budget-middle ?))
	(not (budget-high ?))
	(not (repair ?))
	=>
	(assert (budget-low (yes-or-no-p "Budget is less than 40 000 (yes/no)? "))))
   
(defrule determine-budget-state-middle ""
	(budget-low no)
	(not (budget-middle ?))
	(not (budget-high ?))
	(not (repair ?))
	=>
	(assert (budget-middle (yes-or-no-p "Budget is more than 40 000, but less than 80 000 (yes/no)? "))))
   
(defrule determine-budget-state-high ""
	(budget-low no)
	(budget-middle no)
	(not (budget-high ?))
	(not (repair ?))
	=>
	(assert (budget-high (yes-or-no-p "Budget is more than 80 000 (yes/no)? "))))     
   
(defrule determine-children ""   
	(or (or (budget-low yes)      
                (budget-middle yes)) 
	    (budget-high yes))
	(not (repair ?))
	=>
	(assert (children (yes-or-no-p "Are you planning to go on vacation with children (yes/no)? "))))

(defrule determine-category-low ""   
	(budget-low yes)
	(children yes)
	(not (repair ?))
	=>
	(assert (category-low yes)))
   
(defrule determine-category-middle ""   
	(or (and(budget-middle yes)
                (children yes))
            (and(budget-low yes)
                (children no)))	
	(not (repair ?))
	=>
	(assert (category-middle yes)))
   
(defrule determine-category-high ""  
	(or(and(or(budget-high yes)
		  (budget-middle yes))
	       (children no))	
	    (and (budget-high yes)
                 (children yes))) 			
	(not (repair ?))
	=>
	(assert (category-high yes)))
   
(defrule determine-abroad ""
	(or (category-middle yes)      
	    (category-high yes))
	(not (repair ?))
	=>
	(assert (abroad (yes-or-no-p "Do you want to spend your holiday abroad (yes/no)? ")))) 
   
(defrule determine-russia ""  
	(category-low yes)			
	(not (repair ?))
	=>
	(assert (abroad no)))
	
(defrule determine-visa ""  
	(abroad yes)			
	(not (repair ?))
	=>
	(assert (visa (yes-or-no-p "Do you agree to get a visa if you don't have one (yes/no)? "))))
   
(defrule determine-excursion ""  
	(not (excursion ?))			
	(not (repair ?))
	=>
	(assert (excursion (yes-or-no-p "Is the purpose of your trip an excursion (yes/no)? "))))
   
(defrule determine-beach ""  
	(excursion no)			
	(not (repair ?))
	=>
	(assert (beach (yes-or-no-p "Is the purpose of your trip to the beach (yes/no)? "))))
   
(defrule determine-ski ""  
	(excursion no)
	(beach no)
	(not (repair ?))
	=>
	(assert (ski (yes-or-no-p "The purpose of your trip is a ski resort (yes/no)? "))))
   
(defrule determine-winter ""  
	(not (winter ?))
	(not (repair ?))
	=>
	(assert (winter (yes-or-no-p "Will your vacation take place in winter (yes/no)? "))))
   
(defrule determine-spring ""  
	(winter no)
	(not (repair ?))
	=>
	(assert (spring (yes-or-no-p "Will your vacation take place in spring (yes/no)? "))))
   
(defrule determine-summer ""  
	(winter no)
	(spring no)
	(not (repair ?))
	=>
	(assert (summer (yes-or-no-p "Will your vacation take place in summer (yes/no)? "))))
   
(defrule determine-autumn ""  
	(winter no)
	(spring no)
	(summer no)
	(not (repair ?))
	=>
	(assert (autumn (yes-or-no-p "Will your vacation take place in autumn (yes/no)? "))))

;;;****************
;;;* REPAIR RULES *
;;;****************

(defrule determine-budget-no ""
	(and(and(budget-low no)
		(budget-middle no))
	    (budget-high no))
	(not (repair ?))
	=>
	(assert (repair "No options. Check budget. ")))
   
(defrule determine-season-no ""
	(and(and(and(winter no)
		    (spring no))
                (summer no))
	    (autumn no))
	(not (repair ?))
	=>
	(assert (repair "No options. Check season. ")))

(defrule Petersburg ""
	(and(and(abroad no)
                (category-middle yes))
	    (excursion yes))
	(not (repair ?))
	=>
	(assert (repair "St. Petersburg.")))
	
(defrule Perm ""
	(and(and(abroad no)
                (category-low yes))
	    (excursion yes))
	(not (repair ?))
	=>
	(assert (repair "Perm.")))
   
	(defrule Sochi-ski ""
	(and(and(and(abroad no)
                    (category-middle yes))
	        (ski yes))
	     (or (or (winter yes)
                     (autumn yes))
	         (spring yes)))
	(not (repair ?))
	=>
	(assert (repair "Sochi ski resort.")))
   
(defrule Sochi-beach""
	(and(and(and(abroad no)
                    (summer yes))
                (beach yes))
	     (or (category-low yes)
	         (category-middle yes)))
	(not (repair ?))
	=>
	(assert (repair "Sochi beach resort.")))
   
(defrule UAE""
	(and(and(and(abroad yes)
                    (category-high yes))
		(beach yes))
	     (or (winter yes)
		 (autumn yes)))	   
	(not (repair ?))
	=>
	(assert (repair "United Arab Emirates.")))
   
(defrule Turkey ""
	(and(and(and(abroad yes)
		    (category-middle yes))
		(beach yes))
	     (or (spring yes)
		 (summer yes)))	   
	(not (repair ?))
	=>
	(assert (repair "Turkey.")))
   
(defrule Egypt ""
	(and(and(and(abroad yes)
                    (category-middle yes))
		(beach yes))
	    (or (spring yes)
		(autumn yes)))	   
	(not (repair ?))
	=>
	(assert (repair "Egypt.")))
   
(defrule Germany-ski""
	(and(and(and(and(and(abroad yes)
                            (category-high yes))
                        (visa yes))
                    (ski yes))
                (children no))
	   (winter yes))	   
	(not (repair ?))
	=>
	(assert (repair "Germany ski resort.")))   
	
(defrule Germany-excursion""
	(and(and(and(and(abroad yes)
                        (category-high yes))
                    (visa yes))
                 (excursion yes))
            (children no))   
	(not (repair ?))
	=>
	(assert (repair "Germany excursion.")))
   
(defrule Spain-ski""
	(and(and(and(and(and(abroad yes)
                            (category-high yes))
		        (visa yes))
		    (ski yes))
	        (winter yes))
	     (children yes))   
	(not (repair ?))
	=>
   (assert (repair "Spain ski resort.")))
   
(defrule Spain-beach""
	(and(and(and(and(and(abroad yes)
			    (category-high yes))
			(visa yes))
		    (beach yes))
                 (summer yes))
	    (children yes))   
	(not (repair ?))
	=>
	(assert (repair "Spain beach resort.")))
   
(defrule China""
	(and(and(and(and(abroad yes)
                        (category-high yes))
                    (visa yes))
                 (excursion yes))
             (children yes))   
	(not (repair ?))
	=>
	(assert (repair "China.")))
   
(defrule no-repairs ""
	(declare (salience -10))
	(not (repair ?))
	=>
	(assert (repair "No options.")))
   
;;;********************************
;;;* STARTUP AND CONCLUSION RULES *
;;;********************************

(defrule system-banner ""
	(declare (salience 10))
	=>
	(printout t crlf crlf)
	(printout t "The Engine Diagnosis Expert System")
	(printout t crlf crlf))

(defrule print-repair ""
	(declare (salience 10))
	(repair ?item)
	=>
	(printout t crlf crlf)
	(printout t "Suggested Resort:")
	(printout t crlf crlf)
	(format t " %s%n%n%n" ?item))


