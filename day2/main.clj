#!/usr/bin/env bb
(ns main (:require 
           [clojure.java.io :as io]
           [clojure.string :as str])) 



(defn get-items
  [acc line]
  (let  [tokens (str/split line #"\s+")]
    (conj acc (vec (reduce (fn[a i] (conj a (Integer/parseInt i ))) [] tokens)))))

(defn read-file
  []
  (with-open [rdr (io/reader "input.txt")]
    (reduce get-items [] (line-seq rdr))))

(defn check
  [delta]
  (let [all-neg (every? #(< % 0) delta)
        all-pos (every? #(> % 0) delta)
        within-range (every? #(and(< (abs %) 4)(> (abs %) 0))delta)]
    (and(or all-neg all-pos) within-range)))

(defn check-one-unsafe
  [delta]
  (let [all-neg (every? #(< % 0) delta)
        all-pos (every? #(> % 0) delta)
        within-range (every? #(and(< (abs %) 4)(> (abs %) 0))delta)]
    (and(or all-neg all-pos) within-range)))
    
(defn get-deltas
  [line]
  (->> line
      (partition 2 1)
      (map #(- (nth % 0)(nth % 1)))
      (check)))
      

; part 1 - All Unsafe
(defn all-unsafe
  []
  (println(count (filter true? (map get-deltas (read-file))))))


