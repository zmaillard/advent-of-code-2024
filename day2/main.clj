#!/usr/bin/env bb
(ns main (:require 
           [clojure.java.io :as io]
           [clojure.string :as str])) 

(defn remove-item-by-index
 [items i]
 (concat (subvec items 0 i) (subvec items (inc i))))

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


;(defn check-one-unsafe
;  [delta]
;  (let [neg (map #(< % 0) delta)
;        pos (map #(> % 0) delta)
;        within-range (map #(and(< (abs %) 4)(> (abs %) 0))delta))
;    (mapv #(or %1 %2 %3) neg pos within-range)))
    
(defn get-deltas
  [line]
  (->> line
      (partition 2 1)
      (map #(- (nth % 0)(nth % 1)))
      (check)))

(defn do-unsafe-check
  [orig-line delta]
  (let [all-neg (every? #(< % 0) delta)
        all-pos (every? #(> % 0) delta)
        within-range (every? #(and(< (abs %) 4)(> (abs %) 0))delta)
        is-good (and(or all-neg all-pos) within-range)]
    (if is-good is-good (reduce (fn[acc l] (or acc (get-deltas l))   ) false (map #(remove-item-by-index orig-line %)  (range(count orig-line)))))))

(defn get-deltas-unsafe
  [line]
  (->> line
      (partition 2 1)
      (map #(- (nth % 0)(nth % 1)))
      (do-unsafe-check line)))

; part 1 - All Unsafe
(defn all-unsafe
  []
  (println(count (filter true? (map get-deltas (read-file))))))


; part 2
(defn one-unsafe
  []
  (println(count (filter true? (map get-deltas-unsafe (read-file))))))

(one-unsafe)
