# CloudFormation-Templates

AWS CloudFormation templates for Sample App

Prerequisites:

> Latest image of services in the corresponding ECR Repo.

> Make sure you launch the templates in correct order [Skip the template if not present] and wait for the stacks to reach "Create Complete" stage before moving on to the next stack.

**Name of VPC template should be FoundationVPC or FoundationDevVPC depending on the stack.**

1. VPC Template
2. ALB + NAT Template
3. VPC Link and NLB Template
4. DB (RDS) Template
5. ECS Template
6. Cognito User Pool
7. API Gateway & Authorizer (REST API) Template
