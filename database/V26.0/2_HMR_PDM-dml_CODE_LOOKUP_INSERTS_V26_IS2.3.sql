USE HMR_DEV; -- uncomment appropriate instance
--USE HMR_TST;
--USE HMR_UAT;
--USE HMR_PRD;
GO

INSERT INTO HMR_CODE_LOOKUP (CODE_SET, CODE_NAME, CODE_VALUE_NUM, CODE_VALUE_FORMAT, CONCURRENCY_CONTROL_NUMBER)
VALUES ('VALIDATOR_PROPORTION', 'SURFACE_TYPE_PAVED', 80, 'NUMBER', 1);

INSERT INTO HMR_CODE_LOOKUP (CODE_SET, CODE_NAME, CODE_VALUE_NUM, CODE_VALUE_FORMAT, CONCURRENCY_CONTROL_NUMBER)
VALUES ('VALIDATOR_PROPORTION', 'SURFACE_TYPE_UNPAVED', 80, 'NUMBER', 1);

INSERT INTO HMR_CODE_LOOKUP (CODE_SET, CODE_NAME, CODE_VALUE_NUM, CODE_VALUE_FORMAT, CONCURRENCY_CONTROL_NUMBER)
VALUES ('VALIDATOR_PROPORTION', 'SURFACE_TYPE_UNCNSTR', 20, 'NUMBER', 1);

INSERT INTO HMR_CODE_LOOKUP (CODE_SET, CODE_NAME, CODE_VALUE_NUM, CODE_VALUE_FORMAT, CONCURRENCY_CONTROL_NUMBER)
VALUES ('VALIDATOR_PROPORTION', 'MAINTENANCE_CLASS', 90, 'NUMBER', 1);

INSERT INTO HMR_CODE_LOOKUP (CODE_SET, CODE_NAME, CODE_VALUE_NUM, CODE_VALUE_FORMAT, CONCURRENCY_CONTROL_NUMBER)
VALUES ('VALIDATOR_PROPORTION', 'STRUCTURE_VARIANCE_M', 100, 'NUMBER', 1);