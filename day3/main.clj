#!/usr/bin/env bb
(ns main (:require 
           [clojure.java.io :as io]
           [clojure.string :as str])) 

(defn remove-item-by-index
 [items i]
 (concat (subvec items 0 i) (subvec items (inc i))))


(def left-paren "(")
(def right-paren ")")
(def comma ",")
(defn is-number
  [i]
  (contains? i ["0" "1" "2" "3" "4" "5" "6" "7" "8" "9"]))
  

(defn get-num
  [s start end]
  (try
   (Integer/parseInt (subs s start end))
   (catch Exception _ nil)))

(defn load-values
  [input]
 (for [m (str/split input #"mul")]
   (let [has-paren (str/starts-with? m left-paren)
         comma-idx (str/index-of m comma 1)
         right-paren-idx (if (nil? comma-idx) nil (str/index-of m right-paren comma-idx))]
    (println m)
    (println (if (and has-paren (not (nil? right-paren-idx))){:number-1 (get-num m 1 comma-idx) :number-2 (get-num m (inc comma-idx) right-paren-idx)} {}))
    (if (and has-paren (not (nil? right-paren-idx))){:number-1 (get-num m 1 comma-idx) :number-2 (get-num m (inc comma-idx) right-paren-idx)} {}))))

(defn mult-values
  [acc {i1 :number-1 i2 :number-2}]
  (let [
        is-nil (or (nil? i1)(nil? i2))
        not-is-nil (not is-nil)
        is-large (and not-is-nil (or (> 999 i1)(> 999 i2)))]
    (if  is-nil acc (+ acc (* i1 i2))))) 

;day 1
(defn get-all-mult
  []
  (println(reduce mult-values 0 (load-values(slurp "input.txt")))))


(defn fix-do-dont
  [acc i]
  (let [a (str/index-of i "don't()")
        b (if (nil? a) i (subs i 0 a))]
   (str acc b)))


(println(reduce mult-values 0 (load-values(reduce fix-do-dont  "" (str/split (slurp "input.txt") #"do\(\)")))))
;(println(str/split (slurp "input.txt") #"do\(\)"))


