INSERT INTO PayrollObligations
SELECT DISTINCT ExternalPayrollObligations.RPIO AS RPIO, ExternalPayrollObligations.AhCode AS AhCode, ExternalPayrollObligations.BFY AS BFY, ExternalPayrollObligations.FundCode AS FundCode, ExternalPayrollObligations.FundName AS FundName, ExternalPayrollObligations.OrgCode AS OrgCode, ExternalPayrollObligations.AccountCode AS AccountCode, ExternalPayrollObligations.ProgramProjectCode AS ProgramProjectCode, ExternalPayrollObligations.ProgramProjectName AS ProgramProjectName, ExternalPayrollObligations.RcCode AS RcCode, ExternalPayrollObligations.DivisionName AS DivisionName, ExternalPayrollObligations.FocCode AS FocCode, ExternalPayrollObligations.FocName AS FocName, ExternalPayrollObligations.WorkCode AS WorkCode, ExternalPayrollObligations.WorkCodeName AS WorkCodeName, ExternalPayrollObligations.HrOrgCode AS HrOrgCode, ExternalPayrollObligations.PayPeriod AS PayPeriod, 
SUM(ExternalPayrollObligations.Amount) AS Amount, 
SUM(ExternalPayrollObligations.Hours) AS Hours, 
SUM(ExternalPayrollObligations.CumulativeBenefits) AS CumulativeBenefits, 
SUM(ExternalPayrollObligations.AnnualBasePaid) AS AnnualBase, 
SUM(ExternalPayrollObligations.AnnualBaseHours) AS AnnualHours, 
SUM(ExternalPayrollObligations.AnnualOvertimePaid) AS AnnualOvertimePaid, 
SUM(ExternalPayrollObligations.AnnualOvertimeHours) AS AnnualOvertimeHours, 
SUM(ExternalPayrollObligations.AnnualOtherPaid) AS AnnualOtherPaid, 
SUM(ExternalPayrollObligations.AnnualOtherHours) AS AnnualOtherHours
FROM ExternalPayrollObligations
GROUP BY ExternalPayrollObligations.RPIO, ExternalPayrollObligations.AhCode, ExternalPayrollObligations.BFY, ExternalPayrollObligations.FundCode, ExternalPayrollObligations.FundName, ExternalPayrollObligations.OrgCode, ExternalPayrollObligations.AccountCode, ExternalPayrollObligations.ProgramProjectCode, ExternalPayrollObligations.ProgramProjectName, ExternalPayrollObligations.RcCode, ExternalPayrollObligations.DivisionName, ExternalPayrollObligations.FocCode, ExternalPayrollObligations.FocName, ExternalPayrollObligations.WorkCode, ExternalPayrollObligations.WorkCodeName, ExternalPayrollObligations.HrOrgCode, ExternalPayrollObligations.PayPeriod
ORDER BY ExternalPayrollObligations.BFY DESC , ExternalPayrollObligations.PayPeriod;