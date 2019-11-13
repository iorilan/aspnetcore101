
============================

============================

=================================

===================================


create your own pod yaml:
1. prepare health check function :
public IActionResult CheckHealth () {
        if (new Random ().Next (100) > 50) {
            return Ok ("OK");
        } else {
            return BadRequest ();
        }
    }
	
2.kubectl create -f k8s-web-pod.yaml
apiVersion: v1
kind: Pod # resource type
metadata:
  name: k8s-net-pod # resource name
  labels: # pod label
    app: k8s-net-pod
spec: # pod properties
  containers: # 
    - name: web # pod name in container
      image: aspnetapp # image address of pod
      imagePullPolicy: IfNotPresent # default value is Always means always pull form remote .can set to IfNotPresent or Never to use locally
      ports:
        - containerPort: 80 # pod port (similar to Dockerfile-EXPOSE)
      livenessProbe: # health check
        httpGet:
          path: /Home/CheckHealth # health check path
          port: 80 #health check port

3. kubectl get pods

4. kubectl port-forward k8s-net-pod 8090:80
5. kubectl expose pod k8s-net-pod --name k8s-net-service --type=NodePort
6. kubectl get services

7. kubectl create -f k8s-net-service.yaml
apiVersion: v1
kind: Service # set resource type = service
metadata:
  name: k8s-net-service # resource name
spec:
  selector: # point to pod
    app: k8s-net-pod # pod label = k8s-net-pod
  ports:
  - protocol: TCP # proto type
    port: 80 # service port
    targetPort: 80 # service forwarding port
    nodePort: 30000
  type: NodePort # service port
  
  
 8. kubectl create -f k8s-net-replicaset.yaml
 apiVersion: apps/v1beta2 # rs version number
kind: ReplicaSet # resorce type
metadata:
  name: k8s-net-replicaset # resource name
spec:
  replicas: 3 # number of pod 
  selector: # 
    matchLabels: # 
      app: aspnetapp # 
  template: # 
    metadata:
      labels:
        app: aspnetapp # 
    spec:
      containers:
      - name: k8s-net-replicaset
        image: aspnetapp # image name
        imagePullPolicy: Never # default values is always
		
		
9.
kubectl get rs
kubectl get pods

10.
kubectl expose replicaset k8s-net-replicaset --type=LoadBalancer --port=8091 --target-port=80 --name k8s-net-rs
-service

11. kubectl get pods

12. kubectl delete pod {id}

13. kubectl get pods

14. kubectl scale replicaset k8s-net-replicaset --replicas=6

15. kubectl get pods
 