#!/usr/bin/env bb
(ns main (:require 
           [clojure.java.io :as io]
           [clojure.string :as str])) 


(defn get-cols
  [row-idx row]
  (map-indexed (fn[idx i]{:row row-idx :col idx :value i}) row))

(def get-grid
  (flatten(map-indexed (fn[idx i](get-cols idx i)) (str/split(slurp "input.txt") #"\n"))))


(defn get-val
  [row col grid desired]
  (let [cell-cands (filter #(and (= (:col %) col)(= (:row %) row))grid)
        cell (first cell-cands)]
    (if (nil? cell) false (= (str(:value cell)) (str desired)))))

(defn new-cell
  [{dx :dx dy :dy} cur full-grid]
  (let [x-val (get-val (dy (:row cur)) (dx (:col cur)) full-grid "X")
        m-val (get-val (dy (dy (:row cur))) (dx(dx (:col cur))) full-grid "M")
        a-val (get-val (dy (dy (dy (:row cur)))) (dx(dx(dx (:col cur)))) full-grid "A")
        s-val (get-val (dy (dy (dy (dy (:row cur))))) (dx(dx(dx(dx (:col cur))))) full-grid "S")]
    (if (and x-val m-val a-val s-val) 1 0)))

(defn process
  [acc cur]
  (let [move-right (new-cell {:dx (partial inc) :dy (partial + 0)} cur get-grid)
        move-left (new-cell {:dx (partial dec) :dy (partial + 0)}cur get-grid)
        move-up (new-cell {:dx (partial + 0) :dy (partial dec)}cur get-grid)
        move-down (new-cell {:dx (partial + 0) :dy (partial inc)}cur get-grid)
        move-diag-ur (new-cell {:dx (partial inc) :dy (partial dec)}cur get-grid)
        move-diag-lr (new-cell {:dx (partial inc) :dy (partial inc)}cur get-grid)
        move-diag-ul (new-cell {:dx (partial dec) :dy (partial dec)}cur get-grid)
        move-diag-ll (new-cell {:dx (partial dec) :dy (partial inc)}cur get-grid)]
   (+ acc move-right move-left move-up move-down move-diag-ur move-diag-lr move-diag-ul move-diag-ll)))

(println(reduce process  0 get-grid))
