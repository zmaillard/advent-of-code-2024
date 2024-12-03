#!/usr/bin/env bb
(ns main (:require 
           [clojure.java.io :as io]
           [clojure.string :as str])) 

(defn get-items
  [acc line]
  (let  [tokens (str/split line #"\s+")
         [f s ] tokens]
    (into acc {(Integer/parseInt f) (Integer/parseInt s)})))

(defn read-file
  []
  (with-open [rdr (io/reader "input.txt")]
    (reduce get-items [] (line-seq rdr))))
    

(defn sum-it-up
  [acc [f s]]
  (println (- s f))
  (+ (abs(- s f)) acc))
    

(defn get-instances
  [l1 l2]
  (reduce #(into %1 (vec {%2 (count(filter (fn[x](= x %2))l2))}))[] l1)) 

;part 1
(defn get-space-apart
  []
 (let [data (read-file)
       first (sort(map #(nth % 0) data))
       second (sort(map #(nth % 1) data))
       comb (mapv vector first second)]
   (println(reduce sum-it-up  0 comb))))

;part 2
(defn get-similarity
  []
 (let [data (read-file)
       first (sort(map #(nth % 0) data))
       second (sort(map #(nth % 1) data))
       instances (get-instances first second)]
   (reduce (fn[acc [num count]](+ (* num count) acc))  0 instances)))
   

  
(println (get-similarity))  
